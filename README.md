# Extended Immersive Tour (Unity 360 VR)

An extended 360 degree VR experience built in Unity for Meta Quest (Android). It
opens on a main menu and lets the user choose between two tours: the original
Holberton intranet tour and a custom campus tour made from original 360 photos.
Each tour wraps 360 media around the inside of a sphere and uses controller ray
hotspots to move around, with fade to black transitions between rooms and between
scenes for comfort.

## Scenes

- MainMenuScene: the entry point. Shows the title "ALU 360 Experience" and two
  buttons, Intranet Tour and Custom Campus Tour.
- IntranetTourScene: the original tour of the Holberton space. Four 360 video
  rooms (Living Room, Cantina, Cube, Mezzanine) with navigation hotspots and info
  boxes.
- CustomCampusTourScene: a custom tour made from three original 360 photos, in a
  continuous flow of Top Floor, Resources Center and Leadership Center.

## Navigation

- From the main menu the user opens either tour.
- From inside either tour the user can go back to the main menu or jump straight
  to the other tour, using the two markers near the lower front of the view.
- Every scene change and every room change fades to black and back so the view
  never cuts abruptly.

## Controls

On a Meta Quest headset each controller shows a pointing ray. Aim at a marker and
pull the trigger. A location pin travels to another room or scene, and a chat
bubble opens or closes an info box. Markers grow slightly while the ray is on
them. Head tracking lets the user look around from the centre of each sphere. Free
movement is turned off on purpose so the user stays centred in the 360 view.

## Project structure

- Assets/Scenes: MainMenuScene, IntranetTourScene, CustomCampusTourScene.
- Assets/Videos: the four 360 clips for the intranet tour.
- Assets/CampusMedia: the three original campus 360 photos and their materials.
- Assets/Audio: the background music track.
- Assets/Icons: the location pin and chat bubble hotspot markers.
- Assets/RenderTextures: one render texture per intranet room, filled by its
  video player.
- Assets/Scripts: the tour and navigation logic (see below).
- Assets/InsideOut.shader: an unlit shader that shows the media on the inside of
  the sphere.

## Scripts

- TourManager: keeps one room active at a time and runs the fade to black
  transition between rooms.
- SceneNavigator: fades the view and loads another scene, and fades the view back
  in when a scene first loads.
- SceneButton: a ray target that loads another scene through the SceneNavigator.
- Hotspot: a gaze or ray target that either travels to a room or toggles an info
  box, and highlights while looked at.
- InfoPanel: shows and hides an info box.
- GazePointer: casts a ray from the centre of view for gaze based selection.
- CameraLook: mouse look for testing in the Editor.

## Scenes in build

1. MainMenuScene
2. IntranetTourScene
3. CustomCampusTourScene

## Building for Meta Quest

The project targets Android with IL2CPP and ARM64. Open Build Settings, confirm
the three scenes above are listed with MainMenuScene first, and build into the
Builds folder.

## Credits

Campus 360 photos captured by Donald Duru with the provided campus 360 camera.

Background music: "Tech Live" by Kevin MacLeod (incompetech.com), licensed under
Creative Commons: By Attribution 4.0 License.
https://creativecommons.org/licenses/by/4.0/

360 video clips provided by Holberton School for the original 360 video tour.
