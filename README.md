# 3DCG-Kosen-for-Online-Event

このシステムは私が所属している八戸高専の3DCG内を自由に歩き回ることができるシステムです。

これは、八戸高専本科2, 3年生の時に自主探究活動として制作したシステムです。

八戸高専の3DCGはBlenderで制作しました。（この3DCGは一緒に送信した紹介動画をご覧ください。）

3人共同で行い、私は机や椅子などの物の3DCG制作とUnityでのシステム構築を担当しました。


## Blenderでの3DCG制作

3DCGの制作においては、私が机や椅子などの3DCGの制作を担当し、他2人は建物自体の制作を担当しました。

建物の制作は八戸高専の設計図をお借りしてその縮尺で制作しました。

建物内の机や椅子などの物は、様々な角度からの写真を撮り、それを基に制作しました。

2, 3年次で全ての建物を制作することはできませんでしたが、低学年生の教室などがある講義棟と、先生の居室や保健室などがあるゼミ棟の制作を行いました。

私が制作した3DCGは、以下の通りです。

・時計

・談話スペース（丸テーブルと椅子）

・ゴミ箱（教室用）

・机

・椅子

・教室の棚

・教卓

・教室のライトのスイッチ

・教室の電灯

・ロッカー

・廊下の電灯（2種類）

・掃除用具入れ

・ゼミ棟廊下にある棚（7種類）

・ゼミ棟にある置物

・水道

・階段の電灯

・水飲み場

・エアコン

・暖房

・缶やペットボトル専用のゴミ箱

・配管



## Unityを用いたシステム構築

3DCG内を歩き回ることができるシステムの構築はUnityで行いました。

Blenderで制作した3DCGをUnityに落とし込み、実装を行いました。

自由に歩き回ることができるシステムの制作にあたり、いくつかの機能を実装したので以下に紹介します。


## プレイヤー操作

このリポジトリのPlayerScript.csがプレイヤー操作のスクリプトです。

WASDキーで移動、マウス操作で視点移動、スペースキーでジャンプを行うことができます。

また、プレイヤーとオブジェクトの当たり判定もこのスクリプトに載っています。


## コントローラーでの操作

このリポジトリのPlayerController.csがコントローラーでの操作のスクリプトです。

PCだけの操作ではなく、Xboxのコントローラーなども用いて操作できるようにしています。

基本的なプレイヤーの動きはPlayerScript.csと同じです。


## カメラ切り替え

このリポジトリのChangeCameraView.csがこのスクリプトです。

これは、"1"を押すとカメラが一人称視点になり、"3"を押すとカメラが三人称視点になるという機能です。


## シーン切り替え

このリポジトリのSceneChange.csがこのスクリプトです。

八戸高専の3DCGは容量が重く、1F〜3Fまで一気にロードすると動作しにくくなってしまいます。

そのため、1F、2F、3Fをそれぞれ分けてシーンを作りました。

このシステムでは、それぞれの階の階段にプレイヤーが来たときに、"Press Enter Key"と表示し、この時にエンターキーを押すと次の階があるシーンに移動します。

<img width="500" alt="Kaidan_enterkey" src="https://github.com/Take-Kai/3DCG-Kosen-for-Online-Event/assets/169955027/fffc168a-ae0f-4723-9739-8e311db1161a">



## ドアの開閉

このリポジトリのDoorOpenClose.csがこのスクリプトです。

これは、教室などのドアにプレイヤーが近づいたらそのドアを自動で開閉するというスクリプトです。

ドアの周りに、プレイヤーが来たことを検知する空のオブジェクトを用意し、その範囲内に入ったらドアを開けます。

また、その範囲内からプレイヤーが出るとドアが自動で閉まります。

これは、ドアが開閉するアニメーションを作成し、状態遷移をスクリプトで記述しています。


## ナビゲーション

このリポジトリのNavigationフォルダの中に入っているスクリプトがナビゲーション機能のスクリプトです。

このシステムはオンライン体験入学などに用いるために作成しましたが、対象は中学生となっています。

中学生がこのシステムを利用したときにどのルートを辿ればどの部屋に行くことができるか分かりません。

そのため、マップを用意して、そのマップ上に表示されている部屋をクリックするとプレイヤーの目の前に矢印が現れ、行きたい部屋を指し続けるという機能を実装しました。

この機能は、空のオブジェクトのアクティブ・非アクティブの切り替えによって実装しています。



## 課題・今後の展望

現段階では、講義棟とゼミ棟の3DCGを作成しました。

しかし、ゼミ棟にある物はまだ全て制作できていません。

また、自由に歩き回る際の機能が不十分であると考えています。

教室に入った時にここではどんなことが行われるのか、どんな実験をするのかなどの情報もあった方が良いと考えています。

また、様々な機能を追加するためにスクリプトを作りましたが、別のワールドを生成して作成を進めたため、八戸高専の3DCGに実装できていないものもあります。

今後はUnityでの機能追加をメインに進めていけば、講義棟とゼミ棟に関しては完成するのではないかと思います。

また、八戸高専はこの2つの建物だけではなく、体育館やものづくりセンター、各コース棟などもあるので体験入学で使用するとなった場合はこれらも作成する必要があると考えています。


