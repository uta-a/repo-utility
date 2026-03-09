using BepInEx;
using BepInEx.Logging;

namespace REPOUtility;

[BepInPlugin("com.utaa.repoutil", "REPOUtility", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    internal static Plugin Instance;
    internal static ManualLogSource Log;

    private void Awake()
    {
        Instance = this;
        Log = Logger;
        Logger.LogInfo("REPOUtility loaded");
    }
}
