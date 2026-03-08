# Chat & TTS

## Core Types

### ChatManager

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public static | `ChatManager` | instance |
| protected | `Boolean` | chatActive |
| protected | `Boolean` | localPlayerAvatarFetched |
| protected | `Boolean` | textMeshFetched |
| protected | `PlayerAvatar` | playerAvatar |
| protected | `String` | prevChatMessage |
| protected | `String` | chatMessage |
| public | `TextMeshProUGUI` | chatText |
| private | `Single` | spamTimer |
| private | `List<String>` | chatHistory |
| private | `Int32` | chatHistoryIndex |
| private | `Single` | possessLetterDelay |
| private | `Boolean` | wasPossessed |
| private | `Int32` | wasPossessedPrio |
| private | `Boolean` | betrayalActive |
| protected | `PossessChatID` | activePossession |
| protected | `Single` | activePossessionTimer |
| public | `PossessChatID` | currentPossessChatID |
| private | `List<PossessMessageBatch>` | possessBatchQueue |
| private | `PossessMessageBatch` | currentBatch |
| private | `Int32` | currentMessageIndex |
| private | `Boolean` | isScheduling |
| private | `PossessMessageBatch` | scheduledBatch |
| private | `Single` | isSpeakingTimer |
| private | `ChatState` | chatState |
| private | `PossessMessage` | currentPossessMessage |

### ChatManager.ChatState

| Value | Name |
|-------|------|
| 0 | Inactive |
| 1 | Active |
| 2 | Possessed |
| 3 | Send |

### ChatManager.PossessChatID

| Value | Name |
|-------|------|
| 0 | None |
| 1 | LovePotion |
| 2 | Ouch |
| 3 | SelfDestruct |
| 4 | Betrayal |
| 5 | SelfDestructCancel |

### TTSDirector

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public static | `TTSDirector` | instance |
| protected | `TTSEngine` | engine |

### TTSVoice

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| protected | `PlayerAvatar` | playerAvatar |
| protected | `Boolean` | isPlayerAvatarDisabledPrev |
| public | `Text` | baseFreqHzLabel |
| public | `Speech[]` | voices |
| protected | `String` | voiceText |
| protected | `Int32` | voiceTextWordIndex |
| protected | `Boolean` | isSpeaking |
| protected | `AudioSource` | audioSource |
| private | `Speech` | activeVoice |
| private | `Int32` | activeVoiceNum |
| private | `Int32` | voiceBaseFrequency |
| private | `VoicingSource` | voicingSource |
| private | `List<String>` | words |
| protected | `Single` | currentWordTime |
| private | `Single` | tumbleCooldown |
| private | `Single` | noClipLoudnessTimer |

### TruckScreenText

Base: `MonoBehaviour`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `ScreenTextRevealDelaySettings` | textRevealNormalSetting |
| public | `ScreenNextMessageDelaySettings` | nextMessageDelayNormalSetting |
| public | `GameObject` | staticGrabCollider |
| public static | `TruckScreenText` | instance |
| private | `StaticGrabObject` | staticGrabObject |
| public | `ScreenType` | screenType |
| public | `String` | chatMessageString |
| public | `TextMeshProUGUI` | chatMessage |
| public | `UnityEvent` | onChatMessage |
| private | `Single` | chatMessageTimer |
| private | `Single` | chatMessageTimerMax |
| private | `Boolean` | chatActive |
| private | `PhotonView` | photonView |
| private | `Int32` | chatCharacterIndex |
| private | `Single` | chatDeactivatedTimer |
| private | `String` | nicknameTaxman |
| private | `String` | currentNickname |
| private | `Boolean` | screenActive |
| private | `Int32` | nextPageOverride |
| public | `Transform` | chatMessageLoadingBar |
| public | `Transform` | chatMessageResultBar |
| public | `Light` | chatMessageResultBarLight |
| protected | `Single` | chatMessageResultBarTimer |
| private | `Single` | chatActiveTimer |
| private | `Boolean` | selfDestructingPlayers |
| private | `TuckScreenLocked` | truckScreenLocked |
| private | `String` | chatMessageIdleString1 |
| private | `String` | chatMessageIdleString2 |
| private | `String` | chatMessageIdleStringCurrent |
| private | `Single` | chatMessageIdleStringTimer |
| protected | `PlayerChatBoxState` | playerChatBoxState |
| private | `Boolean` | playerChatBoxStateStart |
| public | `List<CustomEmojiSounds>` | customEmojiSounds |
| public | `Sound` | typingSound |
| public | `Sound` | emojiSound |
| public | `Sound` | newLineSound |
| public | `Sound` | newPageSound |
| public | `Sound` | chargeChatLoop |
| public | `Sound` | chatMessageResultSuccess |
| public | `Sound` | chatMessageResultFail |
| public | `RawImage` | background |
| public | `Color` | mainBackgroundColor |
| public | `Color` | offBackgroundColor |
| public | `Color` | evilBackgroundColor |
| public | `Color` | transitionBackgroundColor |
| private | `Single` | arrowPointAtGoalTimer |
| private | `Single` | engineSoundTimer |
| public | `Transform` | engineSoundTransform |
| public | `Sound` | engineRevSound |
| public | `Sound` | engineSuccessSound |
| public | `TextMeshProUGUI` | textMesh |
| public | `String` | testingText |
| public | `List<TextPages>` | pages |
| private | `Int32` | currentPageIndex |
| private | `Int32` | currentLineIndex |
| private | `Int32` | currentCharIndex |
| private | `Single` | typingTimer |
| protected | `Single` | delayTimer |
| protected | `Boolean` | isTyping |
| private | `Single` | backgroundColorChangeTimer |
| private | `Single` | backgroundColorChangeDuration |
| private | `Single` | startWaitTimer |
| private | `Boolean` | started |
| private | `Boolean` | lobbyStarted |

### TruckScreenText.LobbyScreenPage

| Value | Name |
|-------|------|
| 0 | Start |
| 1 | FailFirst |
| 2 | FailSecond |
| 3 | FailThird |
| 4 | HitRoad |

### TruckScreenText.PlayerChatBoxState

| Value | Name |
|-------|------|
| 0 | Idle |
| 1 | Typing |
| 2 | LockedDestroySlackers |
| 3 | LockedStartingTruck |

### TruckScreenText.ScreenType

| Value | Name |
|-------|------|
| 0 | TruckScreen |
| 1 | TruckLobbyScreen |
| 2 | TruckShopScreen |

### TruckScreenText.ShopScreenPage

| Value | Name |
|-------|------|
| 0 | Start |
| 1 | NotEnough |
| 2 | Enough |
| 3 | Stealing |
| 4 | AllPlayersInTruck |

### TruckScreenText.TruckScreenPage

| Value | Name |
|-------|------|
| 0 | Start |
| 1 | EndNotEnough |
| 2 | EndEnough |
| 3 | AllPlayersInTruck |

## Other Types

### ChatUI

Base: `SemiUI`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public static | `ChatUI` | instance |
| public | `TextMeshProUGUI` | chatText |

### LobbyChatUI

Base: `SemiUI`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| private | `TTSVoice` | ttsVoice |
| private | `MenuPlayerListed` | menuPlayerListed |
| private | `Single` | prevWordTime |
| public | `Boolean` | isSpectate |
| public | `Boolean` | isGameplay |
| public | `TextMeshProUGUI` | spectateName |
| private | `RectTransform` | rectTransform |
| private | `Single` | chatOffsetXPos |
| private | `Boolean` | offsetFetched |
| private | `String` | prevPlayerName |

### ScreenNextMessageDelaySettings

Base: `ScriptableObject`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Single` | delay |

### ScreenTextRevealDelaySettings

Base: `ScriptableObject`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| public | `Single` | delay |

### WorldSpaceUITTS

Base: `WorldSpaceUIChild`

#### Fields

| Modifier | Type | Name |
|----------|------|------|
| protected | `TextMeshProUGUI` | text |
| protected | `Single` | wordTime |
| protected | `TTSVoice` | ttsVoice |
| protected | `Transform` | followTransform |
| protected | `PlayerAvatar` | playerAvatar |
| protected | `Vector3` | offsetPosition |
| private | `Single` | flashTimer |
| private | `Color` | textColor |
| private | `Color` | textColorTarget |
| private | `Boolean` | flashDone |
| public | `AnimationCurve` | curveIntro |
| private | `Single` | curveLerp |
| protected | `Vector3` | followPosition |
| private | `Single` | alphaCheckTimer |
| private | `Single` | textAlphaTarget |
| private | `Single` | textAlpha |
| private | `Camera` | cameraMain |

