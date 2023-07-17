# Animation Pro
AnimationProはUnity用のUIおよびその他のアニメーションシステムです。これにより、プロジェクトにスムーズなアニメーションを簡単に追加するためのシンプルなAPIを提供します。  
  
[![NPM Package](https://img.shields.io/npm/v/com.matuyuhi.animationpro)](https://www.npmjs.com/package/com.matuyuhi.animationpro)
[![openupm](https://img.shields.io/npm/v/com.matuyuhi.animationpro?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.matuyuhi.animationpro/)
[![Licence](https://img.shields.io/npm/l/com.matuyuhi.animationpro)](https://github.com/Matuyuhi/AnimationPro/blob/main/LICENSE)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/de7a60820baa4b41b0532f66d850d2bc)](https://app.codacy.com/gh/Matuyuhi/AnimationPro/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![npm](https://img.shields.io/npm/dt/com.matuyuhi.animationpro.svg)](https://npmjs.com/package/com.matuyuhi.animationpro)
#### Switch Language
- [English(英語)](./README.md)
## Installation

このパッケージをNPM経由でUnityプロジェクトにインストールするには、
以下の手順を守ってください：

1. Unityプロジェクトを開き、Packagesフォルダに移動します。
2. manifest.jsonという新しいファイルを作成します（存在しない場合）。
3. manifest.jsonファイルを開き、次の行を "dependencies" セクションに追加します：
```json
{
    "dependencies": {
        "com.matuyuhi.animationpro": "${other version}"
    }
}
```

1. manifest.jsonファイルを保存して閉じます。
2. Unityエディタを開きます。パッケージマネージャは自動的にAnimationProパッケージをインストールします。

## Usage
### [アニメーション一覧](./ANIMATIONS.md)
AnimationProの基本的な使用例は以下の通りです：

``` csharp
// Attach UITransform Component in gameObject
// Get the UITransform
 a = GetComponent<UITransform>();
// 左側へ2秒かけて画面を水平方向にスライドアウトさせてフェードアウトします
a.Animation(
    a.SlideHorizontal(new AnimationSpec(2f, 0f), AP.DirectionHorizontal.Left) + 
    a.FadeOut(new AnimationSpec(2f, 0f))
);
```
## Contributing
バグレポートや機能のリクエストは大歓迎です。
コードを改善できると思われる場合は、どうか遠慮なくプルリクエストを作成してください。
## License
このプロジェクトはMITライセンスの下にライセンスされています。詳細は、[LICENSE file](./LICENSE)をご覧ください。

## Author
このプロジェクトは[Matuyuhi](https://github.com/Matuyuhi)によって作成されました。

## Support or Contact Information
質問、問題、または貢献したい場合は、このリポジトリで問題を開くか、直接私に連絡してください。
- Project: https://github.com/Matuyuhi/AnimationPro
- Email: bird9.yuhi@gmail.com
- Github: https://github.com/Matuyuhi