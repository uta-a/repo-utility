using UnityEngine;

namespace REPOUtility;

public static class GameStateHelper
{
    public static bool IsInLevel()
    {
        return SemiFunc.RunIsLevel();
    }

    public static bool IsInShop()
    {
        return SemiFunc.RunIsShop();
    }

    public static bool IsInLobby()
    {
        return SemiFunc.RunIsLobby();
    }

    public static bool IsInMainMenu()
    {
        return SemiFunc.IsMainMenu();
    }

    public static bool IsInTutorial()
    {
        return SemiFunc.RunIsTutorial();
    }

    public static int GetLevelsCompleted()
    {
        return RunManager.instance.levelsCompleted;
    }

    public static Level GetCurrentLevel()
    {
        return RunManager.instance.levelCurrent;
    }

    public static float GetDifficultyMultiplier(int tier)
    {
        switch (tier)
        {
            case 1: return SemiFunc.RunGetDifficultyMultiplier1();
            case 2: return SemiFunc.RunGetDifficultyMultiplier2();
            case 3: return SemiFunc.RunGetDifficultyMultiplier3();
            default:
                Plugin.Log.LogWarning($"Invalid difficulty tier: {tier} (expected 1-3)");
                return 1f;
        }
    }

    public static void CameraShake(float amount, float time)
    {
        SemiFunc.CameraShake(amount, time);
    }

    public static void CameraShakeAtPosition(Vector3 position, float strength, float duration, float distanceMin = 0f, float distanceMax = 20f)
    {
        SemiFunc.CameraShakeDistance(position, strength, duration, distanceMin, distanceMax);
    }
}
