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

To install this package via NPM to your Unity project, follow these steps:

### Install from a Git URL

UPMパッケージを直接Git URLからインストールすることができます。パッケージをGit URLからロードするには:

* [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui.html)のウィンドウを開きます。
* ステータスバーの**+**ボタンをクリックします。
* パッケージを追加するためのオプションが表示されます。
* 追加メニューから、Git URLからパッケージを追加を選択します。テキストボックスと「追加」ボタンが表示されます。
* テキストボックスに`https://github.com/Matuyuhi/AnimationPro.git` のGit URLを入力し、「追加」をクリックします。
* 特定のパッケージバージョンをインストールするには、指定したバージョンのURLを使用します。
    * `https://github.com/Matuyuhi/AnimationPro.git#X.Y.Z`
    * ここで述べられているバージョン`X.Y.Z`は、取得したいバージョンに置き換えてください。
    * 利用可能なすべてのリリースは [here](https://github.com/Matuyuhi/AnimationPro/releases)から見つけることができます。
    * 最新の利用可能なリリースバージョンは
      [![Last Release](https://img.shields.io/github/v/release/Matuyuhi/AnimationPro)](https://github.com/Matuyuhi/AnimationPro/releases/latest)
      です。

Unityがサポートしているプロトコルについての詳細は、[Git URLs](https://docs.unity3d.com/Manual/upm-git.html)をご覧ください。

### Install from NPM

* プロジェクトの`Packages`ディレクトリに移動します。
* テキストエディタで[project manifest file](https://docs.unity3d.com/Manual/upm-manifestPrj.html) `manifest.json` を調整します。
* Ensure `https://registry.npmjs.org/` is part of `scopedRegistries`.
    * `com.matuyuhi`が`scopes`の一部であることを確認します。
    * 最新バージョンを指定して、`com.matuyuhi.animationpro`を`dependencies`に追加します。

最小の例は以下のようになります。ここで述べられているバージョン`X.Y.Z`は、
現在の[the latest released version](https://www.npmjs.com/package/com.matuyuhi.animationpro)
である[![NPM Package](https://img.shields.io/npm/v/com.matuyuhi.animationpro?color=blue)](https://www.npmjs.com/package/com.matuyuhi.animationpro)
に置き換えてください。

```json
{
  "scopedRegistries": [
    {
      "name": "npmjs",
      "url": "https://registry.npmjs.org/",
      "scopes": [
        "com.matuyuhi"
      ]
    }
  ],

  "dependencies": {
    "com.matuyuhi.animationpro": "X.Y.Z"
  }
}
```

1. manifest.jsonファイルを保存して閉じます。
2. Unityエディタを開きます。パッケージマネージャは自動的にAnimationProパッケージをインストールします。

## Usage

### [Component](./Components.md)
コンポーネントに追加することで簡単に使用できるシンプルなアニメーション
- In Playing
<img src="https://github.com/Matuyuhi/AnimationPro/assets/92073990/4b81bb92-b1d1-4214-988c-88b763d182a2" width="70%"/>

- In Setting
<img src="https://github.com/Matuyuhi/AnimationPro/assets/92073990/131da158-6f77-49b6-a22c-8e7592c73f25" width="70%"/>  


### [アニメーション一覧](./ANIMATIONS.md)

AnimationProの基本的な使用例は以下の通りです：  
<img src="https://github.com/Matuyuhi/AnimationPro/assets/92073990/9d79f6ce-39f2-46fa-875e-f5b1f2f125cb" width="70%"/>
- コード
``` csharp
public class SampleAnimation : AnimationBehaviour
{
  // onClick method attach button
  public void OnClick()
  {
    Animation(
      this.SlideOutHorizontal(AnimationAPI.DirectionHorizontal.Right, Easings.CircIn(0.8f)) +
      this.FadeOut(Easings.CircIn(0.5f, 0.2f)),
      new AnimationListener()
      {
        OnFinished = () =>
        {
            gameObject.SetActive(false);
            // imp animation finished callback
        }
      }
    );
  }
}
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
