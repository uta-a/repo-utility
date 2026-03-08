using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

class Inspector
{
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

                foreach (var f in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    var vis = f.IsPublic ? "public" : f.IsPrivate ? "private" : "protected";
                    var stat = f.IsStatic ? " static" : "";
                    Console.WriteLine($"  F: {vis}{stat} {PrettyType(f.FieldType)} {f.Name}");
                }

                foreach (var p in t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    var stat = (p.GetMethod?.IsStatic ?? p.SetMethod?.IsStatic ?? false) ? " static" : "";
                    Console.WriteLine($"  P:{stat} {PrettyType(p.PropertyType)} {p.Name}");
                }

                foreach (var m in t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    if (m.Name.StartsWith("get_") || m.Name.StartsWith("set_")) continue;
                    var vis = m.IsPublic ? "public" : m.IsPrivate ? "private" : "protected";
                    var stat = m.IsStatic ? " static" : "";
                    var pars = string.Join(", ", m.GetParameters().Select(p => $"{PrettyType(p.ParameterType)} {p.Name}"));
                    Console.WriteLine($"  M: {vis}{stat} {PrettyType(m.ReturnType)} {m.Name}({pars})");
                }
            }
        }
    }
}
