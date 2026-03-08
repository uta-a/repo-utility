# SpawnHelper

エネミー・アイテム・バリュアブルのスポーンを提供するヘルパークラス。全メソッドがホスト専用。

## セットアップ

### .csproj への参照追加

```xml
<Reference Include="REPOUtility">
  <HintPath>path\to\REPOUtility.dll</HintPath>
  <Private>false</Private>
</Reference>
```

### BepInDependency の宣言

```csharp
[BepInDependency("com.utaa.repoutil")]
[BepInPlugin("com.example.mymod", "MyMod", "1.0.0")]
public class Plugin : BaseUnityPlugin { }
```

## メソッド一覧

| メソッド | シグネチャ | 説明 |
|---|---|---|
| SpawnEnemy | `GameObject SpawnEnemy(EnemySetup setup, Vector3 position)` | 指定セットアップのエネミーをスポーン（**ホスト専用**） |
| SpawnRandomEnemy | `GameObject SpawnRandomEnemy(int tier, Vector3 position)` | 指定ティアからランダムにエネミーをスポーン（**ホスト専用**） |
| SpawnItem | `GameObject SpawnItem(string prefabPath, Vector3 position)` | アイテムをスポーン（**ホスト専用**） |
| SpawnValuable | `GameObject SpawnValuable(string prefabPath, Vector3 position)` | バリュアブルをスポーン（**ホスト専用**） |
| SpawnTeleportEffect | `void SpawnTeleportEffect(Vector3 position)` | テレポートエフェクトを再生 |

## 使用例

### ティア1のエネミーをランダムスポーンする

```csharp
if (PlayerHelper.IsMasterClient())
{
    Vector3 spawnPos = new Vector3(10f, 0f, 10f);
    GameObject enemy = SpawnHelper.SpawnRandomEnemy(1, spawnPos);

    if (enemy != null)
    {
        Logger.LogInfo($"スポーン成功: {enemy.name}");
    }
}
```

### 特定のエネミーセットアップを指定してスポーンする

```csharp
if (PlayerHelper.IsMasterClient())
{
    List<EnemySetup> tier2 = EnemyHelper.GetEnemySetups(2);
    if (tier2.Count > 0)
    {
        // リストの先頭のエネミーをスポーン
        Vector3 pos = TeleportHelper.GetLocalPlayerPosition() + Vector3.forward * 5f;
        SpawnHelper.SpawnEnemy(tier2[0], pos);
    }
}
```

### アイテムをスポーンする

```csharp
if (PlayerHelper.IsMasterClient())
{
    Vector3 pos = TeleportHelper.GetLocalPlayerPosition() + Vector3.forward * 2f;
    GameObject item = SpawnHelper.SpawnItem("Items/Flashlight", pos);

    if (item != null)
    {
        SpawnHelper.SpawnTeleportEffect(pos); // 演出を追加
    }
}
```

### バリュアブルをスポーンする

```csharp
if (PlayerHelper.IsMasterClient())
{
    Vector3 pos = TeleportHelper.GetLocalPlayerPosition() + Vector3.right * 3f;
    SpawnHelper.SpawnValuable("Valuables/Diamond", pos);
}
```

### プレイヤーの周囲に複数エネミーをスポーンする

```csharp
if (PlayerHelper.IsMasterClient())
{
    Vector3 center = TeleportHelper.GetLocalPlayerPosition();

    for (int i = 0; i < 5; i++)
    {
        float angle = i * (360f / 5) * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * 8f;
        SpawnHelper.SpawnRandomEnemy(1, center + offset);
    }
}
```

## 注意事項

- **全てのスポーンメソッドはホスト（MasterClient）またはシングルプレイヤー専用**。クライアントから呼び出すと警告ログが出力され `null` が返る。
- マルチプレイ時は `PhotonNetwork.Instantiate` でネットワーク同期付きスポーンが行われる。シングルプレイ時は `Object.Instantiate` が使われる。
- `SpawnItem` / `SpawnValuable` の `prefabPath` は `Resources` フォルダからの相対パス（拡張子なし）を指定する。存在しないパスを指定するとシングルプレイ時に警告ログが出力され `null` が返る。
- `SpawnEnemy` は `EnemySetup.spawnObjects` の先頭要素を使用する。セットアップに有効なスポーンオブジェクトが含まれていない場合は `null` が返る。
- `SpawnTeleportEffect` は内部的に `TeleportHelper.PlayTeleportEffect` を呼び出している。
