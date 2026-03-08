using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

class Inspector
{
    static readonly BindingFlags AllDeclared = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;

    static string PrettyType(Type t)
    {
        if (t == null) return "?";
        if (t.IsByRef) return PrettyType(t.GetElementType()) + "&";
        if (t.IsArray) return PrettyType(t.GetElementType()) + "[]";
        if (t.IsGenericType)
        {
            var name = t.Name;
            var idx = name.IndexOf('`');
            if (idx > 0) name = name.Substring(0, idx);
            var args = string.Join(", ", t.GetGenericArguments().Select(PrettyType));
            return $"{name}<{args}>";
        }
        return t.Name;
    }

    static void WriteEnum(Type t, string displayName)
    {
        Console.WriteLine($"### {displayName}");
        Console.WriteLine();
        Console.WriteLine("| Value | Name |");
        Console.WriteLine("|-------|------|");
        foreach (var f in t.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
        {
            var raw = f.GetRawConstantValue();
            Console.WriteLine($"| {raw} | {f.Name} |");
        }
        Console.WriteLine();
    }

    static void WriteClassSection(Type t, string heading, List<Type> enumPool)
    {
        Console.WriteLine($"### {heading}");
        Console.WriteLine();
        if (t.BaseType != null)
            Console.WriteLine($"Base: `{PrettyType(t.BaseType)}`");
        Console.WriteLine();

        var fields = t.GetFields(AllDeclared).ToArray();
        if (fields.Length > 0)
        {
            Console.WriteLine("#### Fields");
            Console.WriteLine();
            Console.WriteLine("| Modifier | Type | Name |");
            Console.WriteLine("|----------|------|------|");
            foreach (var f in fields)
            {
                var vis = f.IsPublic ? "public" : f.IsPrivate ? "private" : "protected";
                var stat = f.IsStatic ? " static" : "";
                Console.WriteLine($"| {vis}{stat} | `{PrettyType(f.FieldType)}` | {f.Name} |");
            }
            Console.WriteLine();
        }

        var props = t.GetProperties(AllDeclared).ToArray();
        if (props.Length > 0)
        {
            Console.WriteLine("#### Properties");
            Console.WriteLine();
            Console.WriteLine("| Type | Name |");
            Console.WriteLine("|------|------|");
            foreach (var p in props)
            {
                var stat = (p.GetMethod?.IsStatic ?? p.SetMethod?.IsStatic ?? false) ? " (static)" : "";
                Console.WriteLine($"| `{PrettyType(p.PropertyType)}` | {p.Name}{stat} |");
            }
            Console.WriteLine();
        }

        // Nested enums from the pool
        var nested = enumPool.Where(e => e.DeclaringType == t).ToList();
        foreach (var ne in nested)
            WriteEnum(ne, $"{t.Name}.{ne.Name}");
    }

    static void Main(string[] args)
    {
        var managedDir = @"D:\SteamLibrary\steamapps\common\REPO\REPO_Data\Managed";
        var dllPath = Path.Combine(managedDir, "Assembly-CSharp.dll");

        // Only use managed dir DLLs to avoid mscorlib conflict
        var paths = Directory.GetFiles(managedDir, "*.dll");

        var resolver = new PathAssemblyResolver(paths);
        using var mlc = new MetadataLoadContext(resolver, "mscorlib");
        var asm = mlc.LoadFromAssemblyPath(dllPath);

        var mode = args.Length > 0 ? args[0] : "types";

        if (mode == "types")
        {
            foreach (var t in asm.GetTypes().OrderBy(t => t.FullName))
                Console.WriteLine(t.FullName);
        }
        else if (mode == "members")
        {
            var typeName = args.Length > 1 ? args[1] : "";
            foreach (var t in asm.GetTypes().OrderBy(t => t.FullName))
            {
                if (!string.IsNullOrEmpty(typeName) && t.FullName != typeName && !t.FullName.Contains(typeName))
                    continue;

                Console.WriteLine($"\n=== {t.FullName} ===");
                if (t.BaseType != null)
                    Console.WriteLine($"  Base: {PrettyType(t.BaseType)}");

                foreach (var f in t.GetFields(AllDeclared))
                {
                    var vis = f.IsPublic ? "public" : f.IsPrivate ? "private" : "protected";
                    var stat = f.IsStatic ? " static" : "";
                    Console.WriteLine($"  F: {vis}{stat} {PrettyType(f.FieldType)} {f.Name}");
                }

                foreach (var p in t.GetProperties(AllDeclared))
                {
                    var stat = (p.GetMethod?.IsStatic ?? p.SetMethod?.IsStatic ?? false) ? " static" : "";
                    Console.WriteLine($"  P:{stat} {PrettyType(p.PropertyType)} {p.Name}");
                }

                foreach (var m in t.GetMethods(AllDeclared))
                {
                    if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_")) continue;
                    var vis = m.IsPublic ? "public" : m.IsPrivate ? "private" : "protected";
                    var stat = m.IsStatic ? " static" : "";
                    var pars = string.Join(", ", m.GetParameters().Select(p => $"{PrettyType(p.ParameterType)} {p.Name}"));
                    Console.WriteLine($"  M: {vis}{stat} {PrettyType(m.ReturnType)} {m.Name}({pars})");
                }
            }
        }
        else if (mode == "items")
        {
            var allTypes = asm.GetTypes();

            // SemiFunc enums related to items
            var semiFuncEnumNames = new[] { "itemType", "itemVolume", "emojiIcon", "itemSecretShopType" };

            // Collect target types
            bool IsItemType(Type t)
            {
                if (t.FullName == null) return false;
                if (t.FullName.Contains("<>") || t.FullName.Contains("<PrivateImplementationDetails>")) return false;
                // Item-prefixed types (top-level only, not nested under non-Item parents)
                if (t.Name.StartsWith("Item") && t.DeclaringType == null) return true;
                // SemiFunc nested enums
                if (t.DeclaringType?.Name == "SemiFunc" && t.IsEnum && semiFuncEnumNames.Contains(t.Name)) return true;
                return false;
            }

            var itemTypes = allTypes.Where(IsItemType).ToList();
            // Also include nested types of Item* classes (e.g. ItemGun+State)
            var nestedOfItem = allTypes.Where(t => t.DeclaringType != null && t.DeclaringType.Name.StartsWith("Item") && t.DeclaringType.DeclaringType == null && !t.FullName.Contains("<>")).ToList();
            foreach (var nt in nestedOfItem)
                if (!itemTypes.Contains(nt)) itemTypes.Add(nt);

            // Categorize
            var semiFuncEnums = itemTypes.Where(t => t.DeclaringType?.Name == "SemiFunc" && t.IsEnum).OrderBy(t => t.Name).ToList();
            var itemEnums = itemTypes.Where(t => t.IsEnum && t.DeclaringType?.Name != "SemiFunc").OrderBy(t => t.FullName).ToList();
            var coreTypeNames = new[] { "Item", "ItemAttributes", "ItemManager" };
            var coreTypes = itemTypes.Where(t => coreTypeNames.Contains(t.Name) && t.DeclaringType == null).OrderBy(t => Array.IndexOf(coreTypeNames, t.Name)).ToList();
            var concreteTypes = itemTypes.Where(t => !t.IsEnum && t.DeclaringType == null && !coreTypeNames.Contains(t.Name)).OrderBy(t => t.Name).ToList();

            Console.WriteLine("# Items");
            Console.WriteLine();

            // --- Enums section ---
            Console.WriteLine("## Enums");
            Console.WriteLine();

            foreach (var e in semiFuncEnums)
                WriteEnum(e, $"SemiFunc.{e.Name}");

            // --- Core types section ---
            Console.WriteLine("## Core Types");
            Console.WriteLine();

            foreach (var t in coreTypes)
                WriteClassSection(t, t.Name, itemEnums);

            // --- Concrete item classes section ---
            Console.WriteLine("## Concrete Item Classes");
            Console.WriteLine();

            foreach (var t in concreteTypes)
                WriteClassSection(t, t.Name, itemEnums);
        }
        else if (mode == "chat")
        {
            var allTypes = asm.GetTypes();

            // Chat/TTS type filter
            var explicitNames = new HashSet<string> { "ScreenTextRevealDelaySettings", "ScreenNextMessageDelaySettings", "LobbyChatUI", "WorldSpaceUITTS" };
            var prefixes = new[] { "Chat", "TTS", "TruckScreenText" };

            bool IsChatType(Type t)
            {
                if (t.FullName == null) return false;
                if (t.Namespace != null) return false;
                if (t.FullName.Contains("<>")) return false;
                // Only top-level types for matching
                if (t.DeclaringType != null) return false;
                if (explicitNames.Contains(t.Name)) return true;
                foreach (var p in prefixes)
                    if (t.Name.StartsWith(p)) return true;
                return false;
            }

            var chatTypes = allTypes.Where(IsChatType).ToList();
            // Also include nested types of matched classes
            var nestedTypes = allTypes.Where(t => t.DeclaringType != null && chatTypes.Contains(t.DeclaringType) && !t.FullName.Contains("<>")).ToList();
            foreach (var nt in nestedTypes)
                if (!chatTypes.Contains(nt)) chatTypes.Add(nt);

            // Categorize
            var enums = chatTypes.Where(t => t.IsEnum).OrderBy(t => t.FullName).ToList();
            var coreTypeNames = new[] { "ChatManager", "TTSDirector", "TTSVoice", "TruckScreenText" };
            var coreTypes = chatTypes.Where(t => coreTypeNames.Contains(t.Name) && t.DeclaringType == null).OrderBy(t => Array.IndexOf(coreTypeNames, t.Name)).ToList();
            var otherTypes = chatTypes.Where(t => !t.IsEnum && t.DeclaringType == null && !coreTypeNames.Contains(t.Name)).OrderBy(t => t.Name).ToList();

            Console.WriteLine("# Chat & TTS");
            Console.WriteLine();

            // --- Enums section ---
            if (enums.Any(e => e.DeclaringType == null))
            {
                Console.WriteLine("## Enums");
                Console.WriteLine();
                foreach (var e in enums.Where(e => e.DeclaringType == null))
                    WriteEnum(e, e.Name);
            }

            // --- Core types section ---
            Console.WriteLine("## Core Types");
            Console.WriteLine();

            foreach (var t in coreTypes)
                WriteClassSection(t, t.Name, enums);

            // --- Other types section ---
            if (otherTypes.Any())
            {
                Console.WriteLine("## Other Types");
                Console.WriteLine();

                foreach (var t in otherTypes)
                    WriteClassSection(t, t.Name, enums);
            }
        }
    }
}
