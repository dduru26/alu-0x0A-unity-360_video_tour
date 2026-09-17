using UnityEngine;

namespace Tour360
{
    /// <summary>
    /// A gaze or controller-ray target that loads another scene through the
    /// SceneNavigator. Used for the main menu buttons and for the "back to menu"
    /// and "go to the other tour" markers inside each tour. It grows a little
    /// while looked at, matching the room hotspots.
    /// </summary>
    public class SceneButton : MonoBehaviour
    {
        /// <summary>Navigator that performs the fade and scene load.</summary>
        public SceneNavigator navigator;

        /// <summary>Exact name of the scene to open (must be in Build Settings).</summary>
        public string targetScene;

        /// <summary>Object scaled up while the button is looked at.</summary>
        public Transform highlightTarget;

        private Vector3 baseScale;

        private void Awake()
        {
            if (highlightTarget == null)
                highlightTarget = transform;
            baseScale = highlightTarget.localScale;
        }

        /// <summary>Loads the target scene.</summary>
        public void Activate()
        {
            if (navigator != null)
                navigator.Go(targetScene);
        }

        /// <summary>Shows or clears the looked-at feedback.</summary>
        public void SetHighlight(bool on)
        {
            highlightTarget.localScale = on ? baseScale * 1.2f : baseScale;
        }
    }
}
