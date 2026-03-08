using BepInEx;
using BepInEx.Logging;

namespace REPOUtility;

[BepInPlugin("com.utaa.repoutil", "REPOUtility", "1.0.0")]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log;

    private void Awake()
    {
        Log = Logger;
        Logger.LogInfo("REPOUtility loaded");
    }
}
