# 3DCG八戸高専　　　学内探検システム

八戸高専の校内を自由に歩き回り，体験入学のオンライン開催を目指して開発を進めたシステムです．

Blenderによるモデリングと，Unityによる快適な操作・ナビゲーションシステムを構築しました．

詳細は[Notionページ](https://wholesale-beginner-8e9.notion.site/347306a87b4980d481f2d9815bac4a0a?v=347306a87b498023832d000cf5d8d356&p=347306a87b4980608213f1c1dc3f3595&pm=c)からご覧いただけます．

また，作成した3DCGは[Google Drive](https://drive.google.com/file/d/1VZ20wzq4VO_b-SDYMW3PEDTEmWwVOT-K/view?usp=sharing)から動画にてご覧いただけます．

---

## ⚒️ 開発環境
- **Engine**：Unity 2020.3.16f1
- **Modeling**：Blender 2.8

## 📁 メイン処理

### 1. プレイヤー制御 & カメラ切り替え
ユーザの没入感と操作性を両立させるための制御
- [PlayerScript.cs](./PlayerScript.cs) / [PlayerController.cs](./PlayerController.cs)
  - WASD移動，視点操作，プレイヤーの当たり判定．コントローラ入力にも対応．
- [ChangeCameraView.cs](./ChangeCameraView.cs)
  - 一人称/三人称視点の切り替え．
 
### 2. 軽量化
- [SceneChange.cs](./SceneChange.cs)
  - シーンの分割ロード．階ごとにシーンを分割し，階段でのキーボード操作によりロードを行うことでメモリ消費を抑える．
 
### 3. その他機能
- [DoorOpenClose.cs](./DoorOpenClose.cs)
  - プレイヤーが近づいたことを検知してドアを自動で開閉．
- [Navi_map.cs](./Navigation/Navi_map.cs) / [Navi_button.cs](./Navigation/Navi_button.cs)
  - 作成したマップ上の部屋名を選択すると，プレイヤーの前に動く矢印が表示され，目的地を示す．

 ---
## 🎨 Blenderによるモデリング
設計図に基づき，講義棟，ゼミ棟を再現（チームメンバーの成果）．私は主に机や椅子などのインテリアの制作を担当しました．

- **制作物の例**：机，椅子，ロッカー，エアコン，水道，教室/廊下の電灯，配管
- **作成のこだわり**：現物の写真を多角的に何枚も撮影し，詳細にこだわって作成．
- **CGの軽量化**：3DCGモデルはリアリティを維持しつつ，ポリゴン数を削減．物理演算を用いずに布感などを表現.
