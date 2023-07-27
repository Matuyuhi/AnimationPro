# Animation Pro
![view](https://github.com/Matuyuhi/AnimationPro/assets/92073990/cd70e1b7-9630-4094-a000-4a9f8e8a54d4)

AnimationPro is a UI and other animation system for Unity. It provides you with a simple API to add smooth animations to
your project with ease.

[![NPM Package](https://img.shields.io/npm/v/com.matuyuhi.animationpro)](https://www.npmjs.com/package/com.matuyuhi.animationpro)
[![openupm](https://img.shields.io/npm/v/com.matuyuhi.animationpro?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.matuyuhi.animationpro/)
[![Licence](https://img.shields.io/npm/l/com.matuyuhi.animationpro)](https://github.com/Matuyuhi/AnimationPro/blob/main/LICENSE)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/de7a60820baa4b41b0532f66d850d2bc)](https://app.codacy.com/gh/Matuyuhi/AnimationPro/dashboard?utm_source=gh&utm_medium=referral&utm_content=&utm_campaign=Badge_grade)
[![npm](https://img.shields.io/npm/dt/com.matuyuhi.animationpro.svg)](https://npmjs.com/package/com.matuyuhi.animationpro)

#### Switch Language

- [Japanese(日本語)](./README-ja.md)

## Installation

To install this package via NPM to your Unity project, follow these steps:

### Install from a Git URL

You can install the UPM package via directly Git URL. To load a package from a Git URL:

* Open [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) window.
* Click the add **+** button in the status bar.
* The options for adding packages appear.
* Select Add package from git URL from the add menu. A text box and an Add button appear.
* Enter the `https://github.com/Matuyuhi/AnimationPro.git` Git URL in the text box and click Add.
* You may also install a specific package version by using the URL with the specified version.
    * `https://github.com/Matuyuhi/AnimationPro.git#X.Y.Z`
    * Please note that the version `X.Y.Z` stated here is to be replaced with the version you would like to get.
    * You can find all the available releases [here](https://github.com/Matuyuhi/AnimationPro/releases).
    * The latest available release version
      is [![Last Release](https://img.shields.io/github/v/release/Matuyuhi/AnimationPro)](https://github.com/Matuyuhi/AnimationPro/releases/latest)

For more information about what protocols Unity supports, see [Git URLs](https://docs.unity3d.com/Manual/upm-git.html).

### Install from NPM

* Navigate to the `Packages` directory of your project.
* Adjust the [project manifest file](https://docs.unity3d.com/Manual/upm-manifestPrj.html) `manifest.json` in a text
  editor.
* Ensure `https://registry.npmjs.org/` is part of `scopedRegistries`.
    * Ensure `com.matuyuhi` is part of `scopes`.
    * Add `com.matuyuhi.animationpro` to the `dependencies`, stating the latest version.

A minimal example ends up looking like this. Please note that the version `X.Y.Z` stated here is to be replaced
with [the latest released version](https://www.npmjs.com/package/com.matuyuhi.animationpro), which is
currently [![NPM Package](https://img.shields.io/npm/v/com.matuyuhi.animationpro?color=blue)](https://www.npmjs.com/package/com.matuyuhi.animationpro).

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

1. Save and close the manifest.json file.
2. Open the Unity editor. The package manager should automatically install the AnimationPro package.

## Usage

### [Component](./Components.md)
Simple animations that can be easily used by adding them to components  
- In Playing
<img src="https://github.com/Matuyuhi/AnimationPro/assets/92073990/4b81bb92-b1d1-4214-988c-88b763d182a2" width="70%"/>

- In Setting
<img src="https://github.com/Matuyuhi/AnimationPro/assets/92073990/131da158-6f77-49b6-a22c-8e7592c73f25" width="70%"/>  


### [Animations Document file](./ANIMATIONS.md)

Here's a basic example of how to use AnimationPro:

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

We welcome bug reports and feature requests. Please feel free to make a pull request if you believe you can improve the
code.

## License

This project is licensed under the MIT license. For more information, please see the [LICENSE file](./LICENSE).

## Author

This project was created by [Matuyuhi](https://github.com/Matuyuhi).

## Support or Contact Information

If you have any questions, issues, or want to contribute, feel free to open an issue in this repository or contact me
directly.

- Project: https://github.com/Matuyuhi/AnimationPro
- Email: bird9.yuhi@gmail.com
- Github: https://github.com/Matuyuhi
