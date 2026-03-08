using UnityEngine;

namespace REPOUtility;

public static class TeleportHelper
{
    public static void TeleportLocalPlayer(Vector3 position)
    {
        var controller = PlayerController.instance;
        if (controller == null)
        {
            Plugin.Log.LogWarning("TeleportLocalPlayer: PlayerController.instance is null");
            return;
        }

        controller.rb.position = position;
        controller.rb.velocity = Vector3.zero;
        PlayTeleportEffect(position);
    }

    public static void TeleportPlayer(PlayerAvatar player, Vector3 position)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("TeleportPlayer: host-only method called from client");
            return;
        }

        player.playerTransform.position = position;
    }

    public static void TeleportObject(PhysGrabObject obj, Vector3 position)
    {
        var rb = obj.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Plugin.Log.LogWarning("TeleportObject: no Rigidbody found");
            return;
        }

        rb.position = position;
        rb.velocity = Vector3.zero;
    }

    public static void TeleportEnemy(Enemy enemy, Vector3 position)
    {
        enemy.transform.position = position;
    }

    public static Vector3 GetLocalPlayerPosition()
    {
        var controller = PlayerController.instance;
        if (controller == null)
        {
            Plugin.Log.LogWarning("GetLocalPlayerPosition: PlayerController.instance is null");
            return Vector3.zero;
        }

        return controller.transform.position;
    }

    public static void PlayTeleportEffect(Vector3 position)
    {
        if (AssetManager.instance == null || AssetManager.instance.prefabTeleportEffect == null)
        {
            Plugin.Log.LogWarning("PlayTeleportEffect: AssetManager or prefab not available");
            return;
        }

        Object.Instantiate(AssetManager.instance.prefabTeleportEffect, position, Quaternion.identity);
    }
}
