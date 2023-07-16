# Animation Pro
AnimationPro is a UI and other animation system for Unity. It provides you with a simple API to add smooth animations to your project with ease.

## Switch Language
- [Japanese(日本語)](./README-ja.md)
## Installation

To install this package via NPM to your Unity project, follow these steps:

1. Open your Unity project and navigate to the Packages folder.
2. Create a new file named manifest.json if it doesn't exist.
3. Open the manifest.json file and add the following line to the "dependencies" section:
```json
{
    "dependencies": {
        "com.matuyuhi.animationpro": "${other version}"
    }
}
```

1. Save and close the manifest.json file.
2. Open the Unity editor. The package manager should automatically install the AnimationPro package.

## Usage

### [Document file](./ANIMATIONS.md)
Here's a basic example of how to use AnimationPro:

``` csharp
// Attach UITransform Component in gameObject
// Get the UITransform
 a = GetComponent<UITransform>();
// Slide out screen horizontal direction & fade out
// to the right over 3 second
a.Animation(
    a.SlideInHorizontal(new AnimationSpec(2f, 0f), AP.DirectionHorizontal.Left) + 
    a.FadeOut(new AnimationSpec(3f, 0f))
);
```
## Contributing
We welcome bug reports and feature requests. Please feel free to make a pull request if you believe you can improve the code.

## License
This project is licensed under the MIT license. For more information, please see the [LICENSE file](./LICENSE).

## Author
This project was created by [Matuyuhi](https://github.com/Matuyuhi).

## Support or Contact Information
If you have any questions, issues, or want to contribute, feel free to open an issue in this repository or contact me directly.

- Project: https://github.com/Matuyuhi/AnimationPro
- Email: bird9.yuhi@gmail.com
- Github: https://github.com/Matuyuhi