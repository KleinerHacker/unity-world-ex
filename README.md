# unity-world-ex
Extension for Unity to support worlds instead of scenes. Worlds are multiple scenes.

# usage
Use this repository directly in Unity.

### Dependencies
* https://github.com/KleinerHacker/unity-editor-ex
* https://github.com/KleinerHacker/unity-blending
* https://github.com/KleinerHacker/unity-scene-ex

### Open UPM
URL: https://package.openupm.com

Scope: org.pcsoft

# usage
Use `WorldSystem` as base class for your own system. 
Additional use `WorldData` as base for one world, based on an Enum.

This project adds support for worlds. A double click on a world asset opens all contained scenes.