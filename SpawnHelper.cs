using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace REPOUtility;

public static class SpawnHelper
{
    public static GameObject SpawnEnemy(EnemySetup setup, Vector3 position)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("SpawnEnemy: host-only method called from client");
            return null;
        }

        if (setup.spawnObjects == null || setup.spawnObjects.Count == 0)
        {
            Plugin.Log.LogWarning("SpawnEnemy: no spawn objects in setup");
            return null;
        }

        var prefabRef = setup.spawnObjects[0];
        if (prefabRef == null || !prefabRef.IsValid())
        {
            Plugin.Log.LogWarning("SpawnEnemy: spawn object prefab is null or invalid");
            return null;
        }

        if (PhotonNetwork.IsConnected)
            return PhotonNetwork.Instantiate(prefabRef.ResourcePath, position, Quaternion.identity);
        else
            return Object.Instantiate(prefabRef.Prefab, position, Quaternion.identity);
    }

    public static GameObject SpawnRandomEnemy(int tier, Vector3 position)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("SpawnRandomEnemy: host-only method called from client");
            return null;
        }

        List<EnemySetup> setups = EnemyHelper.GetEnemySetups(tier);
        if (setups == null || setups.Count == 0)
        {
            Plugin.Log.LogWarning($"SpawnRandomEnemy: no enemies found for tier {tier}");
            return null;
        }

        var setup = setups[Random.Range(0, setups.Count)];
        return SpawnEnemy(setup, position);
    }

    public static GameObject SpawnItem(string prefabPath, Vector3 position)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("SpawnItem: host-only method called from client");
            return null;
        }

        if (PhotonNetwork.IsConnected)
            return PhotonNetwork.Instantiate(prefabPath, position, Quaternion.identity);
        else
        {
            var prefab = Resources.Load<GameObject>(prefabPath);
            if (prefab == null)
            {
                Plugin.Log.LogWarning($"SpawnItem: prefab not found at {prefabPath}");
                return null;
            }
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }

    public static GameObject SpawnValuable(string prefabPath, Vector3 position)
    {
        if (!SemiFunc.IsMasterClientOrSingleplayer())
        {
            Plugin.Log.LogWarning("SpawnValuable: host-only method called from client");
            return null;
        }

        if (PhotonNetwork.IsConnected)
            return PhotonNetwork.Instantiate(prefabPath, position, Quaternion.identity);
        else
        {
            var prefab = Resources.Load<GameObject>(prefabPath);
            if (prefab == null)
            {
                Plugin.Log.LogWarning($"SpawnValuable: prefab not found at {prefabPath}");
                return null;
            }
            return Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }

    public static void SpawnTeleportEffect(Vector3 position)
    {
        TeleportHelper.PlayTeleportEffect(position);
    }
}
