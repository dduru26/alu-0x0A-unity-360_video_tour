using UnityEngine;

namespace Tour360
{
    /// <summary>Shows or hides an information box in front of the user.</summary>
    public class InfoPanel : MonoBehaviour
    {
        /// <summary>The box that is shown or hidden.</summary>
        public GameObject box;

        /// <summary>True when the box should start open.</summary>
        public bool startOpen;

        private void Start()
        {
            if (box != null)
                box.SetActive(startOpen);
        }

        /// <summary>Flips the box between shown and hidden.</summary>
        public void Toggle()
        {
            if (box != null)
                box.SetActive(!box.activeSelf);
        }
    }
}
