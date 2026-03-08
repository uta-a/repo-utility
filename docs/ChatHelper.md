# ChatHelper

チャットメッセージの送信とTTS（機械音声）の操作を提供するヘルパークラス。

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
| SendMessage | `void SendMessage(string message)` | チャットメッセージを送信（全クライアントでTTS再生される） |
| IsChatActive | `bool IsChatActive()` | チャットがアクティブ（入力中）か |
| IsChatPossessed | `bool IsChatPossessed()` | チャットがPossess状態（敵に操作されている）か |
| SpeakTTS | `void SpeakTTS(string text, bool crouch = false)` | ローカルプレイヤーのTTSでテキストを読み上げ |
| StopTTS | `void StopTTS()` | TTS再生を停止 |
| IsSpeaking | `bool IsSpeaking()` | TTSが読み上げ中か |

## 使用例

### メッセージを送信する

```csharp
ChatHelper.SendMessage("Hello!");
```

送信されたメッセージは全クライアントのチャット画面に表示され、TTS音声で読み上げられる。

### チャット状態を確認してから送信する

```csharp
if (!ChatHelper.IsChatActive() && !ChatHelper.IsChatPossessed())
{
    ChatHelper.SendMessage("Ready to go!");
}
```

### ローカルでTTS読み上げを行う

```csharp
ChatHelper.SpeakTTS("Warning: enemy nearby");
```

`SendMessage` と異なり、ローカルプレイヤーのTTSのみで再生される（チャットには表示されない）。

### しゃがみ状態でTTSを再生する

```csharp
ChatHelper.SpeakTTS("Sneaking...", crouch: true);
```

`crouch` を `true` にすると、しゃがみ時の声質で再生される。

### TTS再生を停止する

```csharp
if (ChatHelper.IsSpeaking())
{
    ChatHelper.StopTTS();
}
```

### TTSの再生完了を待つ

```csharp
IEnumerator WaitForTTS()
{
    ChatHelper.SpeakTTS("Processing...");
    yield return new WaitUntil(() => !ChatHelper.IsSpeaking());
    Logger.LogInfo("TTS finished");
}
```

## 注意事項

- `SendMessage` は `ChatManager.instance.ForceSendMessage` を内部で使用する。通常のチャット入力と同じく全クライアントに配信される。
- `SpeakTTS` / `StopTTS` はローカルプレイヤーの `PlayerVoiceChat.instance.ttsVoice` を操作する。マルチプレイで他プレイヤーには聞こえない。
- `IsSpeaking` は `TTSVoice.isSpeaking`（protected フィールド）を HarmonyLib の `AccessTools` 経由で取得している。
- `PlayerVoiceChat.instance` がまだ初期化されていない場合（ロビー画面など）、TTS系メソッドは警告ログを出力して早期リターンするか `false` を返す。
