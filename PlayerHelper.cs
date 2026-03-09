using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;

namespace REPOUtility;

public static class PlayerHelper
{
    private static readonly FieldInfo _deadSetField = AccessTools.Field(typeof(PlayerAvatar), "deadSet");
    private static readonly MethodInfo _reviveMethod = AccessTools.Method(typeof(PlayerAvatar), "Revive");

    public static PlayerAvatar GetLocalPlayer()
    {
        return SemiFunc.PlayerAvatarLocal();
    }

    public static List<PlayerAvatar> GetAllPlayers()
    {
        return new List<PlayerAvatar>(SemiFunc.PlayerGetAll());
    }

    public static PlayerAvatar FindByName(string name)
    {
        return SemiFunc.PlayerGetFromName(name);
    }

    public static PlayerAvatar FindBySteamID(string steamID)
    {
        return SemiFunc.PlayerGetFromSteamID(steamID);
    }

    public static PlayerAvatar GetNearest(Vector3 position, float range)
    {
        return SemiFunc.PlayerGetNearestPlayerAvatarWithinRange(range, position, false, default);
    }

    public static void Heal(PlayerAvatar player, int amount)
    {
        var health = player.playerHealth;
        if (health == null) return;

        if (player == GetLocalPlayer())
            health.Heal(amount, true);
        else
            health.HealOther(amount, true);
    }

    public static void Hurt(PlayerAvatar player, int amount)
    {
        var health = player.playerHealth;
        if (health == null) return;

        if (player == GetLocalPlayer())
            health.Hurt(amount, false, -1);
        else
            health.HurtOther(amount, Vector3.zero, false, -1);
    }

    public static void SetGodMode(PlayerAvatar player, bool enabled)
    {
        var health = player.playerHealth;
        if (health == null) return;

        var field = AccessTools.Field(typeof(PlayerHealth), "godMode");
        field.SetValue(health, enabled);
        Plugin.Log.LogInfo($"GodMode {(enabled ? "enabled" : "disabled")} for {player.name}");
    }

    public static void SetInvincible(PlayerAvatar player, float duration)
    {
        var health = player.playerHealth;
        if (health == null) return;

        health.InvincibleSet(duration);
    }

    public static int GetCurrency()
    {
        return SemiFunc.StatGetRunCurrency();
    }

    public static void SetCurrency(int amount)
    {
        SemiFunc.StatSetRunCurrency(amount);
    }

    public static void AddCurrency(int amount)
    {
        int current = SemiFunc.StatGetRunCurrency();
        SemiFunc.StatSetRunCurrency(current + amount);
    }

    public static void SetLives(int lives)
    {
        SemiFunc.StatSetRunLives(lives);
    }

    public static bool IsMasterClient()
    {
        return SemiFunc.IsMasterClientOrSingleplayer();
    }

    public static bool IsDead(PlayerAvatar player)
    {
        if (player == null) return false;
        return (bool)_deadSetField.GetValue(player);
    }

    public static void Revive(PlayerAvatar player)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("Revive: host-only method called from client");
            return;
        }

        if (player == null) return;

        if (!IsDead(player))
        {
            Plugin.Log.LogWarning("Revive: player is not dead");
            return;
        }

        _reviveMethod.Invoke(player, null);
        Plugin.Log.LogInfo($"Revived player: {player.name}");
    }

    public static void Revive(PlayerAvatar player, Vector3 position)
    {
        Revive(player);

        if (!IsDead(player))
            TeleportHelper.TeleportPlayer(player, position);
    }
}
