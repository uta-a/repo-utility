# PlayerHelper

プレイヤーの取得・HP操作・通貨管理・GodMode等を提供するヘルパークラス。

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
| GetLocalPlayer | `PlayerAvatar GetLocalPlayer()` | ローカルプレイヤーを取得 |
| GetAllPlayers | `List<PlayerAvatar> GetAllPlayers()` | 全プレイヤーのリストを取得 |
| FindByName | `PlayerAvatar FindByName(string name)` | 名前でプレイヤーを検索 |
| FindBySteamID | `PlayerAvatar FindBySteamID(string steamID)` | Steam IDでプレイヤーを検索 |
| GetNearest | `PlayerAvatar GetNearest(Vector3 position, float range)` | 指定位置から最も近いプレイヤーを取得 |
| Heal | `void Heal(PlayerAvatar player, int amount)` | プレイヤーを回復 |
| Hurt | `void Hurt(PlayerAvatar player, int amount)` | プレイヤーにダメージを与える |
| SetGodMode | `void SetGodMode(PlayerAvatar player, bool enabled)` | GodModeの有効/無効を切り替え |
| SetInvincible | `void SetInvincible(PlayerAvatar player, float duration)` | 一定時間無敵にする |
| GetCurrency | `int GetCurrency()` | 現在の通貨量を取得 |
| SetCurrency | `void SetCurrency(int amount)` | 通貨量を設定 |
| AddCurrency | `void AddCurrency(int amount)` | 通貨を加算 |
| SetLives | `void SetLives(int lives)` | 残機数を設定 |
| IsMasterClient | `bool IsMasterClient()` | ホストまたはシングルプレイヤーか判定 |
| IsDead | `bool IsDead(PlayerAvatar player)` | プレイヤーが死亡しているか判定 |
| Revive | `void Revive(PlayerAvatar player)` | 死亡したプレイヤーを復活させる（**ホスト専用**） |
| Revive | `void Revive(PlayerAvatar player, Vector3 position)` | 指定位置に復活させる（**ホスト専用**） |

## 使用例

### ローカルプレイヤーの体力を全回復する

```csharp
var player = PlayerHelper.GetLocalPlayer();
PlayerHelper.Heal(player, 100);
```

### 全プレイヤーにGodModeを適用する

```csharp
foreach (var player in PlayerHelper.GetAllPlayers())
{
    PlayerHelper.SetGodMode(player, true);
}
```

### 通貨を追加する

```csharp
PlayerHelper.AddCurrency(500);
Logger.LogInfo($"現在の通貨: {PlayerHelper.GetCurrency()}");
```

### 近くのプレイヤーを一定時間無敵にする

```csharp
Vector3 effectOrigin = PlayerHelper.GetLocalPlayer().transform.position;
var nearby = PlayerHelper.GetNearest(effectOrigin, 10f);
if (nearby != null)
{
    PlayerHelper.SetInvincible(nearby, 5f);
}
```

### 特定プレイヤーを名前で検索してダメージを与える

```csharp
var target = PlayerHelper.FindByName("PlayerName");
if (target != null)
{
    PlayerHelper.Hurt(target, 25);
}
```

### ホスト判定してから処理を実行する

```csharp
if (PlayerHelper.IsMasterClient())
{
    PlayerHelper.SetLives(99);
    PlayerHelper.SetCurrency(10000);
}
```

### 死亡した全プレイヤーを復活させる

```csharp
if (PlayerHelper.IsMasterClient())
{
    foreach (var player in PlayerHelper.GetAllPlayers())
    {
        if (PlayerHelper.IsDead(player))
        {
            PlayerHelper.Revive(player);
        }
    }
}
```

### 死亡したプレイヤーを自分の位置に復活させる

```csharp
var local = PlayerHelper.GetLocalPlayer();
var target = PlayerHelper.FindByName("PlayerName");
if (target != null && PlayerHelper.IsDead(target))
{
    PlayerHelper.Revive(target, local.transform.position);
}
```

## 注意事項

- `Heal` / `Hurt` はローカルプレイヤーとリモートプレイヤーで内部的に異なるメソッドを呼び分けている。対象プレイヤーを意識する必要はない。
- `SetGodMode` は Harmony の `AccessTools` でプライベートフィールドに直接アクセスしている。ゲームのアップデートで内部構造が変更された場合は動作しなくなる可能性がある。
- `GetCurrency` / `SetCurrency` / `AddCurrency` / `SetLives` はラン全体の状態に影響する。
- `Revive` はホスト（MasterClient）またはシングルプレイヤー専用。クライアントから呼び出すと警告ログが出力される。
- `IsDead` は `AccessTools` でプライベートフィールド `deadSet` にアクセスしている。ゲームのアップデートで内部構造が変更された場合は動作しなくなる可能性がある。
- `Revive` は内部的に `PlayerAvatar.Revive()` を Reflection で呼び出している。エフェクト・HP回復・状態リセットはゲーム側で自動実行される。
