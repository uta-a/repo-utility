# Use MetadataLoadContext to inspect without loading dependencies
Add-Type -AssemblyName 'System.Reflection.MetadataLoadContext'

$managedDir = 'D:\SteamLibrary\steamapps\common\REPO\REPO_Data\Managed'
$dllPath = Join-Path $managedDir 'Assembly-CSharp.dll'

# Create a path assembly resolver with all managed DLLs
$paths = Get-ChildItem -Path $managedDir -Filter '*.dll' | Select-Object -ExpandProperty FullName
$resolver = New-Object System.Reflection.PathAssemblyResolver($paths)
$mlc = New-Object System.Reflection.MetadataLoadContext($resolver)

try {
    $asm = $mlc.LoadFromAssemblyPath($dllPath)
    $types = $asm.GetTypes()
    $types | ForEach-Object { $_.FullName } | Sort-Object
} finally {
    $mlc.Dispose()
}
