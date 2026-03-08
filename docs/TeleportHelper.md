# TeleportHelper

プレイヤー・オブジェクト・エネミーのテレポートとエフェクト再生を提供するヘルパークラス。

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
| TeleportLocalPlayer | `void TeleportLocalPlayer(Vector3 position)` | ローカルプレイヤーをテレポート（速度リセット+エフェクト付き） |
| TeleportPlayer | `void TeleportPlayer(PlayerAvatar player, Vector3 position)` | 任意のプレイヤーをテレポート（**ホスト専用**） |
| TeleportObject | `void TeleportObject(PhysGrabObject obj, Vector3 position)` | 物理オブジェクトをテレポート（速度リセット付き） |
| TeleportEnemy | `void TeleportEnemy(Enemy enemy, Vector3 position)` | エネミーをテレポート |
| GetLocalPlayerPosition | `Vector3 GetLocalPlayerPosition()` | ローカルプレイヤーの現在位置を取得 |
| PlayTeleportEffect | `void PlayTeleportEffect(Vector3 position)` | テレポートエフェクトを再生 |

## 使用例

### ローカルプレイヤーを原点にテレポートする

```csharp
TeleportHelper.TeleportLocalPlayer(Vector3.zero);
```

### 現在位置を保存して後で戻る

```csharp
// 位置を保存
Vector3 savedPosition = TeleportHelper.GetLocalPlayerPosition();

// ... 何らかの処理 ...

// 保存した位置に戻る
TeleportHelper.TeleportLocalPlayer(savedPosition);
```

### ホストとして他プレイヤーをテレポートする

```csharp
if (PlayerHelper.IsMasterClient())
{
    var players = PlayerHelper.GetAllPlayers();
    Vector3 gatherPoint = new Vector3(0f, 1f, 0f);

    foreach (var player in players)
    {
        TeleportHelper.TeleportPlayer(player, gatherPoint);
    }
}
```

### オブジェクトをプレイヤーの前に移動する

```csharp
Vector3 playerPos = TeleportHelper.GetLocalPlayerPosition();
Vector3 forward = PlayerController.instance.transform.forward;
Vector3 targetPos = playerPos + forward * 2f + Vector3.up;

PhysGrabObject obj = /* 対象オブジェクト */;
TeleportHelper.TeleportObject(obj, targetPos);
```

### エネミーを別の場所にテレポートする

```csharp
Enemy enemy = EnemyHelper.FindNearest(
    TeleportHelper.GetLocalPlayerPosition(), 20f
);
if (enemy != null)
{
    Vector3 newPos = new Vector3(50f, 0f, 50f);
    TeleportHelper.TeleportEnemy(enemy, newPos);
}
```

### テレポートエフェクトのみを再生する

```csharp
Vector3 effectPos = new Vector3(10f, 0f, 5f);
TeleportHelper.PlayTeleportEffect(effectPos);
```

## 注意事項

- `TeleportPlayer` は **ホスト（MasterClient）またはシングルプレイヤー専用**。クライアントから呼び出すと警告ログが出力され何も起きない。
- `TeleportLocalPlayer` はローカルの `PlayerController.instance` の Rigidbody を直接操作するため、自分自身のテレポートにのみ使用する。
- `TeleportObject` は Rigidbody を持つオブジェクトにのみ対応。Rigidbody がない場合は警告ログが出力される。
- `TeleportLocalPlayer` はテレポートエフェクトが自動で再生されるが、`TeleportPlayer` / `TeleportObject` / `TeleportEnemy` にはエフェクトが含まれない。必要に応じて `PlayTeleportEffect` を併用する。
