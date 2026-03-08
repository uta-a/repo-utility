# GameStateHelper

ゲームの状態判定（レベル・ショップ・ロビー・難易度等）とカメラシェイクを提供するヘルパークラス。

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
| IsInLevel | `bool IsInLevel()` | レベル（ステージ）内か判定 |
| IsInShop | `bool IsInShop()` | ショップ内か判定 |
| IsInLobby | `bool IsInLobby()` | ロビー内か判定 |
| IsInMainMenu | `bool IsInMainMenu()` | メインメニューか判定 |
| IsInTutorial | `bool IsInTutorial()` | チュートリアル中か判定 |
| GetLevelsCompleted | `int GetLevelsCompleted()` | クリア済みレベル数を取得 |
| GetCurrentLevel | `Level GetCurrentLevel()` | 現在のレベルオブジェクトを取得 |
| GetDifficultyMultiplier | `float GetDifficultyMultiplier(int tier)` | 難易度倍率を取得（tier: 1-3） |
| CameraShake | `void CameraShake(float amount, float time)` | カメラシェイクを発生させる |
| CameraShakeAtPosition | `void CameraShakeAtPosition(Vector3 position, float strength, float duration, float distanceMin = 0f, float distanceMax = 20f)` | 指定位置を中心にカメラシェイクを発生させる |

## 使用例

### レベル内でのみ処理を実行する

```csharp
if (GameStateHelper.IsInLevel())
{
    // レベル内限定の処理
    Logger.LogInfo($"クリア済みレベル: {GameStateHelper.GetLevelsCompleted()}");
}
```

### ゲーム状態に応じた分岐処理

```csharp
if (GameStateHelper.IsInMainMenu())
{
    // メインメニュー用の処理
}
else if (GameStateHelper.IsInShop())
{
    // ショップ用の処理
}
else if (GameStateHelper.IsInLevel())
{
    // レベル用の処理
}
```

### 難易度に応じたダメージ計算

```csharp
int baseDamage = 10;
float multiplier = GameStateHelper.GetDifficultyMultiplier(1);
int finalDamage = Mathf.RoundToInt(baseDamage * multiplier);
```

### 爆発時のカメラシェイク演出

```csharp
// プレイヤー視点のシェイク
GameStateHelper.CameraShake(2f, 0.5f);

// 特定位置を中心に距離減衰するシェイク
Vector3 explosionPos = new Vector3(10f, 0f, 5f);
GameStateHelper.CameraShakeAtPosition(explosionPos, 3f, 0.8f, 0f, 30f);
```

### 現在のレベル情報を取得する

```csharp
if (GameStateHelper.IsInLevel())
{
    Level currentLevel = GameStateHelper.GetCurrentLevel();
    Logger.LogInfo($"現在のレベル: {currentLevel.name}");
}
```

## 注意事項

- `GetDifficultyMultiplier` の `tier` は 1〜3 の整数で指定する。範囲外の値を渡すと警告ログが出力され `1f` が返る。
- `CameraShakeAtPosition` はプレイヤーとの距離に応じて効果が減衰する。`distanceMin` 〜 `distanceMax` の範囲で強度が変化する。
- 状態判定メソッド（`IsInLevel` 等）はどのクライアントからでも呼び出せる。
