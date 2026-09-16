# unity-360_video_tour

A 360 degree video VR tour built in Unity for Meta Quest (Android). The user
starts in the Living Room and travels between four rooms of the Holberton space,
each shown as a 360 video wrapped around the inside of a sphere. Every room has
navigation hotspots and one or more info boxes.

## Rooms and navigation

The tour links the rooms like this:

- Living Room to Cantina and back
- Living Room to Cube and back
- Cantina to Cube and back
- Cube to Mezzanine and back

Moving between rooms fades the view to black and then fades the new room in, so
the change is gentle.

## Controls

- On a Meta Quest headset, look at a hotspot to highlight it. Hold your gaze on
  it for a moment to activate it.
- While testing in the Unity Editor, hold the right mouse button and drag to look
  around, then left click a hotspot to activate it (gaze dwell also works).

## Project structure

- Assets/Videos: the four 360 clips (LivingRoom, Cantina, Cube, Mezzanine).
- Assets/Audio: the background music track.
- Assets/RenderTextures: one render texture per room, filled by its video player.
- Assets/Scripts: the tour logic (see below).
- Assets/Scenes/360VideoTour.unity: the single scene of the tour.
- Builds: the Android build output.

## Scripts

- TourManager: keeps one room active at a time and runs the fade to black
  transition between rooms.
- Hotspot: a gaze or click target that either travels to a room or toggles an
  info box, and highlights while looked at.
- InfoPanel: shows and hides an info box.
- GazePointer: casts a ray from the centre of view and activates the hotspot the
  user is looking at.
- CameraLook: mouse look for testing in the Editor.

## Scenes in build

- 360VideoTour

## Building for Meta Quest

The project targets Android. Open Build Settings, switch the platform to Android,
confirm 360VideoTour is the only scene in the list, and build into the Builds
folder as 360VideoTour_MetaQuest.

## Credits

Background music: "Tech Live" by Kevin MacLeod (incompetech.com), licensed under
Creative Commons: By Attribution 4.0 License.
https://creativecommons.org/licenses/by/4.0/

360 video clips provided by Holberton School for the 360 video tour project.
