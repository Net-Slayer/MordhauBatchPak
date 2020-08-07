# MordhauBatchPak
Cook, Pak and Copy Mordhau Modded files
* Validates correct paths set
* Includes Compression flags for Cook and Pak stage
* alerts with sounds to indicate completion of each stage
* automatically generates responsefile for pakking
* Saves paths and settings for next time


# Installation
Extract contents of release to folder and run

# Usage
May require to be run as an administrator
The following steps must be completed AFTER you have set up your level cooking settings in your project file.
_Note that the example structures may differ for you depending on setup_

## Cooking

1. Browse to your "UE4 Editor.exe"
e.g. "E:\Epic\UE_4.20\Engine\Binaries\Win64\UE4Editor.exe"
The app will assume that this is also where UnrealPak.exe is also located.

2. Browse to your "Mordhau.uproject"
e.g. "F:\documents\Unreal Projects\Mordhau\Mordhau\Mordhau.uproject"


If you have set these 2 paths correctly you should see that the "Cook only" button is enabled!

You may now optionally enable cooking compression!
_Please note this increases time taken to cook_

The cooking log will be saved in the same folder that you installed this tool.

## Pakking

3. After completing steps 1 and 2 from cooking, type in the Map folder Name
e.g. If I am cooking a Map called NetTest, My map folder might have the files :"NetTest.umap, TDM_NetTest.umap, SKM_NetTest.umap". My map folder name is NetTest so I browse for the folder: "F:\documents\Unreal Projects\Mordhau\Mordhau\Content\Mordhau\Maps\NetTest"

This also determines the Pak Name.

4. Browse to your Temporary Paks folder
e.g. "E:\Paks"

This is a folder that you create, as a staging directory. The Pak will be built and placed in this folder where it can then be published somewhere else.


The Pak only button should now be enabled!

You now have an option to enable pakking compression!
_Please note this may increase time taken to pak, however pakking stage is significantly quicker than cooking stage_

The pakking log and responsefile required to pak will be saved in the same folder that you installed this tool.

## Copying

5. Optionally browse for a mount folder or server folder or both.
Neither have any special function however:

* I recommend that you set mount folder to your Mordhau Paks folder
This allows you to start the game with the pak already mounted, allowing you to run "open [MapName]" from console.

* I recommend setting server folder to your dedicated/local server's Mordhau paks folder
Allows server to have an up to date version of your map.

Once either of these are set, the "Copy Only" and "Cook, pak and copy" buttons will be enabled.

### That's it you're finished!

# Known issues
* No real progress bar shown, instead App remains in BUSY mode during any build stage.
* No exception handling for the moment
* Will not copy to any Mount/Server Mordhau paks folder if Mordhau instance is running

# Future improvements
These are desired and will hopefully be implemented in no particular order:

* Exception Handling for common errors as found
* Reveal Size before/after compression
* Zip and upload to Mod.io
* Copy to array of folders
* Show cook pak and copy progress asynchronously
* Interpret cooking errors from log
* Interpret Pakking errors from log
* Pak Multiple maps
* Customisation of tool (toggle sounds, save log)

