# REPOUtility

R.E.P.O. の BepInEx MOD 開発を支援するユーティリティライブラリ。
プレイヤー操作、敵管理、アイテム制御、テレポートなど、MOD でよく使う処理を静的メソッドとしてまとめています。

## 機能一覧

| クラス | 概要 |
|--------|------|
| PlayerHelper | プレイヤーの取得・体力操作・通貨管理・ゴッドモード |
| EnemyHelper | 敵の取得・ダメージ・即死・デスポーン |
| ItemHelper | アイテムの取得・検索・インベントリ操作 |
| SpawnHelper | 敵・アイテム・バリュアブルのスポーン（ホスト専用） |
| TeleportHelper | プレイヤー・オブジェクト・敵のテレポート |
| GameStateHelper | ゲーム状態の判定・難易度取得・カメラシェイク |

各クラスの詳細は [docs/](docs/) を参照してください。

## 動作環境

- R.E.P.O.（Steam版）
- BepInEx 5.x
- .NET Standard 2.1

## ビルド

`REPOUtility.csproj` 内の `GameDir` をゲームのインストールパスに書き換えてビルドしてください。

```xml
<GameDir>D:\SteamLibrary\steamapps\common\REPO</GameDir>
```

```
dotnet build
```

ビルド成果物は自動的に `BepInEx\plugins\` にコピーされます。

## プロジェクト構成

```
├── docs/            各 Helper クラスのドキュメント
├── tools/           Inspector（ゲーム内オブジェクト調査ツール）
├── *.cs             Helper クラス + Plugin エントリポイント
├── REPOUtility.csproj
└── .gitignore
```

## ライセンス

MIT
