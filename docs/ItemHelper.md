# ItemHelper

アイテムの取得・検索・トグル・ForceGrabを提供するヘルパークラス。

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
| ToggleItem | `void ToggleItem(ItemAttributes item, bool active)` | アイテムの有効/無効を切り替え |
| GetAllItems | `List<ItemAttributes> GetAllItems()` | スポーン済みの全アイテムを取得 |
| FindItemsByName | `List<ItemAttributes> FindItemsByName(string name)` | 名前でアイテムを部分一致検索 |
| FindNearestItem | `ItemAttributes FindNearestItem(Vector3 position, float range)` | 指定位置から最も近いアイテムを取得 |
| GetLocalInventory | `List<string> GetLocalInventory()` | ローカルプレイヤーのインベントリを取得 |
| ForceGrab | `void ForceGrab(PhysGrabObject obj)` | オブジェクトを強制的にグラブする |

## 使用例

### 全アイテムの一覧をログに出力する

```csharp
var items = ItemHelper.GetAllItems();
foreach (var item in items)
{
    Logger.LogInfo($"Item: {item.name} at {item.transform.position}");
}
```

### 名前でアイテムを検索する

```csharp
var guns = ItemHelper.FindItemsByName("Gun");
Logger.LogInfo($"Gun系アイテム: {guns.Count}個");
```

### 最寄りのアイテムを強制グラブする

```csharp
Vector3 playerPos = TeleportHelper.GetLocalPlayerPosition();
var nearest = ItemHelper.FindNearestItem(playerPos, 10f);

if (nearest != null)
{
    var grabObj = nearest.GetComponent<PhysGrabObject>();
    if (grabObj != null)
    {
        ItemHelper.ForceGrab(grabObj);
    }
}
```

### アイテムをトグル（ON/OFF）する

```csharp
var flashlights = ItemHelper.FindItemsByName("Flashlight");
foreach (var flashlight in flashlights)
{
    ItemHelper.ToggleItem(flashlight, true); // 全てONにする
}
```

### インベントリの内容を確認する

```csharp
var inventory = ItemHelper.GetLocalInventory();
foreach (var itemName in inventory)
{
    Logger.LogInfo($"所持: {itemName}");
}
```

### 特定アイテムをプレイヤーの近くにテレポートする

```csharp
var targets = ItemHelper.FindItemsByName("Key");
Vector3 playerPos = TeleportHelper.GetLocalPlayerPosition();

foreach (var item in targets)
{
    var grabObj = item.GetComponent<PhysGrabObject>();
    if (grabObj != null)
    {
        TeleportHelper.TeleportObject(grabObj, playerPos + Vector3.up);
    }
}
```

## 注意事項

- `FindItemsByName` は部分一致検索（`string.Contains`）で動作する。`"Gun"` で検索すると `"GunRifle"` 等もヒットする。
- `ToggleItem` は対象アイテムに `ItemToggle` コンポーネントが存在する場合のみ動作する。存在しない場合は警告ログが出力される。
- `ForceGrab` はローカルプレイヤーの PhysGrabber を使って強制的にグラブする。他プレイヤーが掴んでいるオブジェクトに対する動作はゲーム側の実装に依存する。
- `GetAllItems` / `FindItemsByName` / `FindNearestItem` は `ItemManager.instance.spawnedItems` を参照するため、スポーン前やシーン遷移中は空リストまたは null が返る可能性がある。
