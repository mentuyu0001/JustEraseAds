# 広告を消すだけのゲーム

大学の文化祭で展示する作品として個人で開発しました。


## プレイ動画

[<img width="538" height="300" alt="Image" src="https://github.com/user-attachments/assets/c607ec22-55f0-4dfd-8729-104f4a43918d" />](https://youtu.be/7wTDX4TUWXs)


## 概要

大量の広告に埋め尽くされた画面から、「✕」ボタンや「スキップ」ボタンを探し出して消していく、Webサイトの閲覧体験を意識したタイムアタックゲームです。  
文化祭ということもあり、学生個人や屋台を出店しているサークルに広告の募集をかけたところ、多くの方々に広告を作成していただけました。ありがたい限りです。


## 操作方法
本作は全てマウスのみで操作します。左クリック以外のボタンは使いません。

## 開発環境と動作環境
### 開発環境
- Windows10
- Unity 2022.3.1f1
### 動作環境
- Windows10, 11

## 主な技術的特徴
本作はパフォーマンス性とメンテナンス性のを意識し、以下の設計思想で構築されています。
- 非同期処理の全面採用  
Update()関数を一切使用せず、UniTaskをベースにした非同期処理を採用し、パフォーマンスの最適化を図っています。


- イベント駆動型アーキテクチャ  
主要な処理はイベント駆動で実行され、コンポーネント側の疎結合性を高めています。


- 拡張性の高い設計  
共通する処理は抽象クラスを使用・継承することで、将来的な仕様変更や機能追加にも柔軟に対応できる構造を目指しました。


- オンライン機能の実装  
Microsoftが提供しているPlayFabを利用し、オンラインランキング機能を実装しています。



## プレイ画面

![Image](https://github.com/user-attachments/assets/be674af2-3207-4547-ba7f-0f36b0ed7be3)
![Image](https://github.com/user-attachments/assets/392057ad-bb5d-434c-b830-eb09bba0c639)
![Image](https://github.com/user-attachments/assets/5f9fba77-6ea7-4879-9d59-9d3c638f4203)
![Image](https://github.com/user-attachments/assets/2096eba6-52f7-4560-b8d3-0ee9f768dc79)
![Image](https://github.com/user-attachments/assets/5f458ca7-0efa-4fa4-be02-fb6fc86554d7)
![Image](https://github.com/user-attachments/assets/389c3eda-659d-4b45-8e6a-b155f5ecbba4)
