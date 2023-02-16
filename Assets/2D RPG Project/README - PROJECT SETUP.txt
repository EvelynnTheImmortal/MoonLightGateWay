How To Set Up The Project

This template starter kit has been created by GameDev.tv. 
By purchasing this asset you also gain access to a series of video tutorials which; explain how to set up the project, give you an understand of how the project is structured, and give you tips on how to expand on the project to make your own cool game. 

Links to these videos are provided in the documentation for this asset.

This template needs a couple of quick steps in order to get it working and playable. 
The video series explains each of the steps in detail and the documentation also provides comprehensive setup instructions.

If you want to skip all of that, here are the steps you need to take if you want to dive in quickly:

1. To fix the initial input error:  Open Package Manager, change the selection to Packages: Unity Registry and search for Input System. Click install and go through the process.
2. To fix the sorting layers:  Open the Town scene. Click on any object. In the inspector, select the Layer pulldown and click on Add Layer. In the top right of this window you'll see an icon that looks like 2 horizontal lines with sliders (inbetween the ? and the three dots). Click on that and then double click on the Layers and Tags Preset. Then open up one of the other scenes and return back to the Town and things should work in correctly arranging the layers. 
3. To ensure the layers show properly: Go to Project Settings (Edit -> Project Settings) and select Graphics. Change the Transparency Sort Mode to Custom Axis. Then change the X, Y, Z values to be X = 0, Y = 1, Z = 0.
4. To fix aspect ratio: Click on your game tab and change from Free Aspect to 1920x1080.
5. To load scenes: Add your Scenes so that they load correctly by going to File -> Build Settings and dragging your scenes into the "Scenes In Build". You can remove the Sample Scene if you have one.

If you get stuck, be sure to watch the set up video.
