using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Tour360
{
    /// <summary>
    /// Casts a ray straight out from the centre of view and works out which
    /// Hotspot the user is looking at. The hotspot activates after a short gaze,
    /// or right away on a left mouse click, so it works with a headset (gaze) and
    /// while testing in the Editor (click). A reticle fills up during the gaze.
    /// A hotspot only fires once per look, so the user must glance away and back
    /// to trigger it again.
    /// </summary>
    public class GazePointer : MonoBehaviour
    {
        /// <summary>How far the gaze ray reaches, in metres.</summary>
        public float rayLength = 20f;

        /// <summary>Seconds of steady gaze needed to activate a hotspot.</summary>
        public float dwellTime = 1.2f;

        /// <summary>Radial image that fills while the user gazes at a hotspot.</summary>
        public Image progress;

        private Hotspot current;
        private float timer;
        private bool armed;

        private void Update()
        {
            Ray ray = new Ray(transform.position, transform.forward);
            Hotspot looked = null;
            RaycastHit info;
            if (Physics.Raycast(ray, out info, rayLength))
                looked = info.collider.GetComponentInParent<Hotspot>();

            if (looked != current)
            {
                if (current != null)
                    current.SetHighlight(false);
                current = looked;
                timer = 0f;
                armed = true;
                if (current != null)
                    current.SetHighlight(true);
            }

            if (current == null)
            {
                if (progress != null)
                    progress.fillAmount = 0f;
                return;
            }

            if (!armed)
                return;

            timer += Time.deltaTime;
            if (progress != null)
                progress.fillAmount = Mathf.Clamp01(timer / dwellTime);

            bool clicked = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
            if (clicked || timer >= dwellTime)
            {
                current.Activate();
                armed = false;
                timer = 0f;
                if (progress != null)
                    progress.fillAmount = 0f;
            }
        }
    }
}
