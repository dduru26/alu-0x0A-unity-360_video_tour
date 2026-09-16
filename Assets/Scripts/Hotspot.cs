using UnityEngine;

namespace Tour360
{
    /// <summary>
    /// A gaze or click target placed inside a room. When activated it either
    /// travels to another room or opens and closes an info box. It also grows
    /// a little while the user is looking at it, as visual feedback.
    /// </summary>
    public class Hotspot : MonoBehaviour
    {
        /// <summary>The two things a hotspot can do.</summary>
        public enum Action
        {
            /// <summary>Travel to another room.</summary>
            GoToRoom,
            /// <summary>Open or close an info box.</summary>
            ToggleInfo
        }

        /// <summary>Chooses travel or info behaviour.</summary>
        public Action action = Action.GoToRoom;

        /// <summary>Tour manager used when travelling to a room.</summary>
        public TourManager manager;

        /// <summary>Name of the room to travel to when the action is GoToRoom.</summary>
        public string targetRoom;

        /// <summary>Info box toggled when the action is ToggleInfo.</summary>
        public InfoPanel infoPanel;

        /// <summary>Object scaled up while the hotspot is looked at.</summary>
        public Transform highlightTarget;

        private Vector3 baseScale;

        private void Awake()
        {
            if (highlightTarget == null)
                highlightTarget = transform;
            baseScale = highlightTarget.localScale;
        }

        /// <summary>Runs the hotspot's behaviour.</summary>
        public void Activate()
        {
            if (action == Action.GoToRoom && manager != null)
                manager.GoTo(targetRoom);
            else if (action == Action.ToggleInfo && infoPanel != null)
                infoPanel.Toggle();
        }

        /// <summary>Shows or clears the looked-at feedback.</summary>
        public void SetHighlight(bool on)
        {
            highlightTarget.localScale = on ? baseScale * 1.2f : baseScale;
        }
    }
}
