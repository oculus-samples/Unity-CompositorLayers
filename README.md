# Unity Compositor Layers

The Compositor Layers demo for Unity was built to demonstrate how developers can consume [Unity's Compositor Layers API](https://developers.meta.com/horizon/documentation/unity/unity-ovroverlay), and to showcase common use cases for compositor layers.

Compositor layers allow developers to render crisper, higher-clarity textures. These provide a superior experience for reading text or watching HD video. Compositor layers also render at the framerate of the compositor -- which can be faster, and is never lower, than the frame rate of your application. See [Meta Quest documentation](https://developers.meta.com/horizon/documentation/unity/os-compositor-layers/) for details about how compositor layers work.

This codebase is available both as a reference and as a template for Unity apps. 

The majority of the Compositor Layers project is licensed under [MIT License](LICENSE), however files from [Text Mesh Pro](http://www.unity3d.com/legal/licenses/Unity_Companion_License) are licensed under their respective licensing terms.

See the [CONTRIBUTING](CONTRIBUTING.md) file for how to help out.

## Getting started

First, ensure you have Git LFS installed by running this command:
```sh
git lfs install
```

Then, clone this repo using the "Code" button above, or this command:
```sh
git clone https://github.com/oculus-samples/Unity-CompositorLayers.git
```

To run the demo, clone this repo and open it in *Unity 2022.3.211f1* or higher. Load the [Assets/Scenes/Intro](Assets/Scenes/Intro.unity) scene.

Open the File > Build Settings window, click the "Android" platform in the menu that appears, and click the "Switch Platform" button. After Unity finishes re-importing, click the "Build And Run" button.

## Compositor Layers In Action

Let's have a look at the Compositor Layer demo in action.

This project consists of 5 scenes. Each scene is meant to demonstrate a different use case, or important property, of compositor layers.

At any point while running the Compositor Layer demo, you can press the menu button (☰) to open the Scene Select menu. There, you can change scenes.

The following sections explain each scene.

## Intro

In this scene, the same Unity UI canvas is rendered normally, and as a compositor layer. The rendering method for the canvas changes automatically, every second. Notice the difference in clarity between the two rendering methods.

## Performance

This scene provides controls for rendering an arbitrary number of canvases. Because compositor layers add per-frame time at the operating system layer, it can be hard to measure the true cost of adding compositor layers to your app. This stress test allows you to check your profiling methodologies. See [Profiling and debugging compositor layers](https://developers.meta.com/horizon/documentation/unity/os-compositor-layers/#profiling-and-debugging-compositor-layers) in the Meta Quest documentation.

## Independence

This scene showcases how compositor layers can have an update cadence, and resolution, independent of your app's update cadence and resolution. This makes them ideal for loading screens.

## LayerShapes

Compositor layers can only render a given texture in a predefined set of meshes, although each mesh can be translated + rotated + scaled. This scene shows every mesh available to developers.

## Filtering

Apps interested in providing a high-quality reading or HD-video-watching experience at any distance, or on moving surfaces, should understand the filtering options available to them. Filtering can remove shimmering effects, and improve readability, in scenarios where the rendered texture is extremely stretched or squashed to fit the shape of its compositor layer.