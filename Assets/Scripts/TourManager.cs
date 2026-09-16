using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

namespace Tour360
{
    /// <summary>
    /// Runs the 360 video tour. Only one room is active at a time. When the user
    /// travels, the view fades to black, the old room is turned off, the new room
    /// is turned on and its video starts, then the view fades back in.
    /// </summary>
    public class TourManager : MonoBehaviour
    {
        /// <summary>All rooms in the tour. Element 0 is the room shown at start.</summary>
        [Tooltip("All rooms in the tour. Element 0 is the starting room.")]
        public List<Room> rooms = new List<Room>();

        /// <summary>Black overlay used for the fade between rooms.</summary>
        [Tooltip("CanvasGroup that covers the view and fades to black.")]
        public CanvasGroup fader;

        /// <summary>Length in seconds of the fade out and, separately, the fade in.</summary>
        [Tooltip("Seconds for the fade out and the fade in.")]
        public float fadeDuration = 0.5f;

        private Room current;
        private bool busy;

        /// <summary>One room in the tour: its root object and its video player.</summary>
        [System.Serializable]
        public class Room
        {
            /// <summary>Name used by hotspots to reach this room.</summary>
            public string name;
            /// <summary>Root object holding the sphere and the room UI.</summary>
            public GameObject root;
            /// <summary>Video player that fills this room's sphere.</summary>
            public VideoPlayer video;
        }

        private void Start()
        {
            for (int i = 0; i < rooms.Count; i++)
                ShowRoom(rooms[i], i == 0);
            if (rooms.Count > 0)
                current = rooms[0];
            if (fader != null)
                fader.alpha = 0f;
        }

        /// <summary>Fades to black, moves to the room with the given name, then fades back.</summary>
        public void GoTo(string roomName)
        {
            if (busy)
                return;
            Room target = rooms.Find(r => r.name == roomName);
            if (target == null || target == current)
                return;
            StartCoroutine(Transition(target));
        }

        private IEnumerator Transition(Room target)
        {
            busy = true;
            yield return Fade(0f, 1f);
            ShowRoom(current, false);
            ShowRoom(target, true);
            current = target;
            yield return Fade(1f, 0f);
            busy = false;
        }

        private void ShowRoom(Room room, bool on)
        {
            if (room == null || room.root == null)
                return;
            if (on)
            {
                room.root.SetActive(true);
                if (room.video != null)
                    room.video.Play();
            }
            else
            {
                if (room.video != null)
                    room.video.Stop();
                room.root.SetActive(false);
            }
        }

        private IEnumerator Fade(float from, float to)
        {
            if (fader == null)
                yield break;
            float t = 0f;
            while (t < fadeDuration)
            {
                t += Time.deltaTime;
                fader.alpha = Mathf.Lerp(from, to, t / fadeDuration);
                yield return null;
            }
            fader.alpha = to;
        }
    }
}
