# EnemyHelper

エネミーの取得・検索・ダメージ・キル・デスポーン・セットアップ取得を提供するヘルパークラス。

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
| GetAllSpawned | `List<EnemyParent> GetAllSpawned()` | スポーン済みの全エネミーを取得 |
| FindNearest | `Enemy FindNearest(Vector3 position, float range)` | 指定位置から最も近いエネミーを取得 |
| Hurt | `void Hurt(EnemyHealth health, int damage, Vector3 direction)` | エネミーにダメージを与える |
| Kill | `void Kill(EnemyHealth health)` | エネミーを即死させる |
| Despawn | `void Despawn(EnemyParent enemyParent)` | エネミーをデスポーンさせる（**ホスト専用**） |
| GetEnemySetups | `List<EnemySetup> GetEnemySetups(int tier)` | 指定ティアのエネミーセットアップ一覧を取得（tier: 1-3） |

## 使用例

### 最寄りのエネミーにダメージを与える

```csharp
Vector3 playerPos = TeleportHelper.GetLocalPlayerPosition();
Enemy nearest = EnemyHelper.FindNearest(playerPos, 15f);

if (nearest != null)
{
    var health = nearest.GetComponent<EnemyHealth>();
    if (health != null)
    {
        Vector3 knockback = (nearest.transform.position - playerPos).normalized;
        EnemyHelper.Hurt(health, 50, knockback);
    }
}
```

### 全エネミーを即死させる

```csharp
foreach (var enemyParent in EnemyHelper.GetAllSpawned())
{
    var health = enemyParent.GetComponentInChildren<EnemyHealth>();
    if (health != null)
    {
        EnemyHelper.Kill(health);
    }
}
```

### 全エネミーをデスポーンさせる（ホスト専用）

```csharp
if (PlayerHelper.IsMasterClient())
{
    var enemies = new List<EnemyParent>(EnemyHelper.GetAllSpawned());
    foreach (var enemyParent in enemies)
    {
        EnemyHelper.Despawn(enemyParent);
    }
}
```

### 特定ティアのエネミーセットアップを確認する

```csharp
List<EnemySetup> tier2Enemies = EnemyHelper.GetEnemySetups(2);
foreach (var setup in tier2Enemies)
{
    Logger.LogInfo($"Tier2 Enemy: {setup.name}");
}
```

### スポーン中のエネミー数をカウントする

```csharp
int count = EnemyHelper.GetAllSpawned().Count;
Logger.LogInfo($"現在のエネミー数: {count}");
```

## 注意事項

- `Despawn` は **ホスト（MasterClient）またはシングルプレイヤー専用**。クライアントから呼び出すと警告ログが出力され何も起きない。
- `Kill` は Harmony の `AccessTools` で現在HPを取得し、それを大幅に上回るダメージを与えることで実装されている。ゲーム内部のキル処理（ドロップ・スコア等）が正常に発火する。
- `GetEnemySetups` の `tier` は 1〜3 の整数で指定する。範囲外の値を渡すと警告ログが出力され空リストが返る。
- `GetAllSpawned` が返すリストは `EnemyParent` 型。`Enemy` や `EnemyHealth` コンポーネントには `GetComponentInChildren` でアクセスする。
