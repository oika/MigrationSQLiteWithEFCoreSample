# Migration SQLite With EFCore Sample

## 利用バージョン等

* .NET 8
* SQLite3
* EntityFrameworkCore 9.0.6

## 環境準備

EF Core CLIツールをグローバルにインストール

> dotnet tool install --global dotnet-ef

## 利用手順

* テーブルスキーマに対応するクラス（Person.cs）とDBに対応するコンテキストクラス（AppDbContext）を作成
* 初期マイグレーションを実行
  > dotnet ef migrations add InitialCreate
* テーブル構造に変更を加える（Person.csにAgeを追加）
* マイグレーションファイルを追加
  > dotnet ef migrations add AddAgeToPersonModel
* Migrations/ 配下のファイルをコミットする
* アプリケーション起動時に `DbContext.Database.Migrate()` を呼び出す
