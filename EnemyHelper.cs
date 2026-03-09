using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace REPOUtility;

public static class EnemyHelper
{
    public static List<EnemyParent> GetAllSpawned()
    {
        return new List<EnemyParent>(EnemyDirector.instance.enemiesSpawned);
    }

    public static Enemy FindNearest(Vector3 position, float range)
    {
        return SemiFunc.EnemyGetNearest(position, range, false);
    }

    public static void Hurt(EnemyHealth health, int damage, Vector3 direction)
    {
        health.Hurt(damage, direction);
    }

    public static void Kill(EnemyHealth health)
    {
        var field = AccessTools.Field(typeof(EnemyHealth), "healthCurrent");
        int current = (int)field.GetValue(health);
        health.Hurt(current + 999, Vector3.zero);
    }

    public static void Despawn(EnemyParent enemyParent)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("Despawn: host-only method called from client");
            return;
        }

        enemyParent.Despawn();
    }

    public static List<EnemySetup> GetEnemySetups(int tier)
    {
        var director = EnemyDirector.instance;
        switch (tier)
        {
            case 1: return director.enemiesDifficulty1;
            case 2: return director.enemiesDifficulty2;
            case 3: return director.enemiesDifficulty3;
            default:
                Plugin.Log.LogWarning($"Invalid enemy tier: {tier} (expected 1-3)");
                return new List<EnemySetup>();
        }
    }
}
