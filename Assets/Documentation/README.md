# Neo Story Toolkit

The idea of creating this toolkit came to life while developing the 

[Find The Hero](https://nara-maloneyahoocom.itch.io/find-the-hero) game for the [GameDev.tv Game Jam 2022](https://itch.io/jam/gamedevtv-jam-2022)

We wanted to create a "complete" game with all the components like
* an event system for the base logic
* a UI
* a movement system
* footstep sounds depending on the ground the player walks on
* a camera system
* a health system
* several scenes
* background music
* pickups
* obstacles

It was also always one of my intentions to create this as a kind of a framework which other game developers, designers or story writers might use as a base for their own games.

# Attention please! This is just a partial release!
This release is just a quick first attempt to offer something that can be used right now. I started working on the tutorial section when I discovered that the **Yarn Spinner** project seems to offer exactly the kind of story telling framework that I was looking for as a future backbone of my Toolkit here. I will try to integrate that with what I've got so far. So until I have something working smoothly I won't upload any new source files.


## Asset Packs used
The asset packs used in this project are all available for free, some of them from the asset store:
*  https://assetstore.unity.com/packages/audio/sound-fx/foley/footsteps-essentials-189879 contains many different footstep sounds
* [Footstep Surface Reader](https://assetstore.unity.com/packages/tools/audio/fsr-footstep-surface-reader-143435) is used to detect the ground the player is walking on
*  https://assetstore.unity.com/packages/2d/gui/icons/pixel-cursors-109256 for the cursor

Due to licensing issues I can not include those free assets in my source, so you have to download them and move them into the **Asset Packs** folder.

The assets under a CC0 license can be found in the CC0 folder.

## The Event System
To make the game logic less dependent on coding and easier for designers to use I decided to implement an event driven system based upon the [Unity Atoms](https://unity-atoms.github.io/unity-atoms/) scriptable objects [^2] framework.
While the amount of "stuff" this framework adds seems to be overwhelming at first it seemed to be a solid foundation to use scriptable objects and have all use cases covered.

E.g. we have a **Health** variable that tracks the player's health. Every time its value changes it _fires_ an event, telling interested listeners to do something. 
- Our UI health bar listens to that **HealthChangedEvent** and adjusts its fill grade to **Health** / **MaxHealth**.
- The player contains a component called **CheckIntRaiseEvent** that checks if **Health** falls below 0 and raises the **HealthBelow0** event
- also on the player there is a component **BoolEventListener** which reacts to this event and performs some actions
  - trigger the die animation, 
  - start a timer for the level restart,
  - disable the player controller,
  - stop character movement
- at the same time other entities in the system might listen to that event as well, e.g. an audio system, playing some death sound, a particle effect, etc.

### Scriptable Objects

**Health**: holds the players health

**HealthChangedEvent**: gets fired each time the Health variable changes

**MaxHealth**: holds the maximum number of health points

**HealthBelow0**: fired when **Health** < 0

**StoryLinePlaying**: holds the current dialogue line to play

**StoryLinePlayingEvent** fires on changes in **StoryLinePlaying**

**StoryLineFinishedPlaying** fired after dialogue audio clip has played

## UI
the UI functionality grew as our game took shape. It consists of a
* top panel
* settings menu
* bottom panel

### Top Panel
it contains the following elements

| health bar| collectibles bar | item1 | item2 | settings | exit |
| --- | --- | --- | --- | --- | ---
| players health | items collected | found item1 | found item 2 | volume sliders, etc | Exit the game |


### Settings Menu
contains the sliders for


| Main | Musik | Voice | Sfx |
--- | --- | --- | ---

<br>

### Bottom Panel
in the Jam game the left panel contained some hints, in the toolkit the left and right parts will hold the speakers portrait
| Bottom left | StoryDisplay | Bottom right |
| --- | --- | --- |
| Text1 | story text line |   |
| Text2 | story text line | placeholder |
| Text3 | story text line |   |

The **StoryDisplay** holds the dialogue system based upon 
* https://github.com/draffauf/unity-dialogue-system
* https://www.youtube.com/watch?v=YJLcanHcJxo

I've added the capability to play audio clips and embedded it into the event system: it listens to changes in the **StoryLinePlayingEvent** and fires **StoryLineFinishedPlaying** when the dialogue line display is done.


## Footstep system

based upon the Footstep Surface Reader asset

I am using step events triggered by animation events in the walk and run animations and from inside the jump script.
One problem there: the mecanim system mixes walk & run thus triggering both events, causing double sounds to be played. Now I am checking if the same foot is triggered twice and skip that.

ToDo: checking speed and trigger different sounds

This document is written in Markdown [^1]


[^1]: https://www.markdownguide.org/cheat-sheet
[^2]: https://learn.unity.com/tutorial/introduction-to-scriptable-objects#