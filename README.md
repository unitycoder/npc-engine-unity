# npc-engine Unity integration

This is Unity integration package for NPC-Engine.  
[NPC-Engine](https://github.com/npc-engine/npc-engine) is a deep learning inference engine for designing NPC AI with natural language.


## Features

- Chat-bot dialogue system.
- SoTA tools like text semantic similarity and text to speech.
- Easy, open source deep learning model standard (ONNX with YAML configs).
- GPU accelerated inference with onnxruntime.

## Getting started

- Download and import [Integration package](https://github.com/npc-engine/npc-engine-unity/releases/tag/v0.0.2)
- Install [dependencies](#dependencies)
- Follow welcome window instructions or do a [manual setup](#manual-setup).
- See tutorials and [API docs](https://npc-engine.github.io/npc-engine-unity/api/NPCEngine.html).

## Tutorials

- [Basic Demo](https://npc-engine.github.io/npc-engine-unity/tutorials/basic_demo.html) tutorial to see the basic usage of the NPC-engine API
- [Advanced Demo](https://npc-engine.github.io/npc-engine-unity/tutorials/advanced_demo.html) to understand how higher-level components work and how to integrate NPC Engine into your game.
- [Scene Setup Tutorial](https://npc-engine.github.io/npc-engine-unity/tutorials/scene_setup.html) to learn how to setup your scene from the ground up.


## Dependencies

- Advanced demo scene requires these free asset store packages:
    - [VIDE dialogues](https://assetstore.unity.com/packages/tools/ai/vide-dialogues-69932)
    - [Modular First Person Controller](https://assetstore.unity.com/packages/3d/characters/modular-first-person-controller-189884)
    - [Low Poly Modular Armours](https://assetstore.unity.com/packages/3d/characters/lowpoly-modular-armors-free-pack-199890)
    - [RPG Poly Pack - Lite](https://assetstore.unity.com/packages/3d/environments/landscapes/rpg-poly-pack-lite-148410)


## Manual setup

This integration package is just a wrapper around python server that actually does the heavy lifting.
These steps are usually done automatically by the welcome dialogue buttons from the unity editor, but they can be done manually if required:

- Download the latest release of [npc-engine](https://github.com/npc-engine/npc-engine/releases)
- Unzip it into the `Assets/StreamingAssets/.npc-engine` folder of your Unity project.
- Create an empty `Assets/StreamingAssets/.models` folder
- Run cmd command from your project folder to download default models:
```
Assets/StreamingAssets/.npc-engine/cli.exe download-default-models --models-path Assets/StreamingAssets/.models
```