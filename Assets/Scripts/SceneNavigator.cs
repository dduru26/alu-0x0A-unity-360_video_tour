using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tour360
{
    /// <summary>
    /// Handles comfortable fade to black transitions between whole scenes. Each
    /// scene begins fully black and fades in when it loads, and calling Go fades
    /// to black before loading the next scene, so every scene change is smooth
    /// and easy on the eyes in VR. The same black overlay is shared with the
    /// room fades inside a tour.
    /// </summary>
    public class SceneNavigator : MonoBehaviour
    {
        /// <summary>Black overlay that covers the view; starts opaque then fades in.</summary>
        [Tooltip("CanvasGroup on the camera that covers the view and fades.")]
        public CanvasGroup fader;

        /// <summary>Seconds for the fade out and, separately, the fade in.</summary>
        [Tooltip("Seconds for each fade.")]
        public float fadeDuration = 0.5f;

        private bool busy;

        private void Awake()
        {
            if (fader != null)
                fader.alpha = 1f;
        }

        private void Start()
        {
            if (fader != null)
                StartCoroutine(Fade(1f, 0f));
        }

        /// <summary>Fades to black then loads the scene with the given name.</summary>
        public void Go(string sceneName)
        {
            if (busy || string.IsNullOrEmpty(sceneName))
                return;
            StartCoroutine(LoadRoutine(sceneName));
        }

        private IEnumerator LoadRoutine(string sceneName)
        {
            busy = true;
            yield return Fade(fader != null ? fader.alpha : 1f, 1f);
            SceneManager.LoadScene(sceneName);
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
