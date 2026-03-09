using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Photon.Pun;
using UnityEngine;

namespace REPOUtility;

public static class SpawnHelper
{
    private static readonly FieldInfo _setupDoneField = AccessTools.Field(typeof(EnemyParent), "SetupDone");
    private static readonly FieldInfo _spawnedField = AccessTools.Field(typeof(EnemyParent), "Spawned");
    private static readonly MethodInfo _spawnMethod = AccessTools.Method(typeof(EnemyParent), "Spawn");

    public static GameObject SpawnEnemy(EnemySetup setup, Vector3 position, bool enableAI = true)
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

        GameObject firstSpawned = null;

        foreach (var prefabRef in setup.spawnObjects)
        {
            if (prefabRef == null || !prefabRef.IsValid())
                continue;

            GameObject spawned;
            if (PhotonNetwork.IsConnected)
                spawned = PhotonNetwork.Instantiate(prefabRef.ResourcePath, position, Quaternion.identity);
            else
                spawned = Object.Instantiate(prefabRef.Prefab, position, Quaternion.identity);

            if (spawned == null) continue;

            firstSpawned ??= spawned;

            var enemyParent = spawned.GetComponent<EnemyParent>()
                           ?? spawned.GetComponentInChildren<EnemyParent>();

            if (enemyParent != null)
            {
                var list = EnemyDirector.instance.enemiesSpawned;
                if (!list.Contains(enemyParent))
                    list.Add(enemyParent);
            }

            var agent = spawned.GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            if (agent != null)
            {
                if (UnityEngine.AI.NavMesh.SamplePosition(position, out var hit, 10f, UnityEngine.AI.NavMesh.AllAreas))
                {
                    spawned.transform.position = hit.position;
                    agent.Warp(hit.position);
                }
            }

            if (enableAI && enemyParent != null)
                Plugin.Instance.StartCoroutine(WaitAndSpawn(enemyParent));
        }

        return firstSpawned;
    }

    public static GameObject SpawnRandomEnemy(int tier, Vector3 position, bool enableAI = true)
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
        return SpawnEnemy(setup, position, enableAI);
    }

    private static IEnumerator WaitAndSpawn(EnemyParent enemyParent)
    {
        float elapsed = 0f;
        while (elapsed < 5f)
        {
            if (enemyParent == null) yield break;
            if ((bool)_setupDoneField.GetValue(enemyParent)) break;
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (enemyParent == null) yield break;

        if (!(bool)_spawnedField.GetValue(enemyParent))
            _spawnMethod.Invoke(enemyParent, null);
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
