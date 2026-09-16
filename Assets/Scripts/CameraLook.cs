using UnityEngine;
using UnityEngine.InputSystem;

namespace Tour360
{
    /// <summary>
    /// Lets you look around by holding the right mouse button and dragging. This
    /// is only for testing the tour in the Editor. It turns itself off when a VR
    /// headset is present, so on the headset the head movement drives the camera.
    /// </summary>
    public class CameraLook : MonoBehaviour
    {
        /// <summary>Turn speed in degrees per unit of mouse movement.</summary>
        public float sensitivity = 0.15f;

        private float yaw;
        private float pitch;

        private void Start()
        {
            Vector3 angles = transform.localEulerAngles;
            yaw = angles.y;
            pitch = angles.x;
        }

        private void Update()
        {
            if (UnityEngine.XR.XRSettings.isDeviceActive)
                return;
            Mouse mouse = Mouse.current;
            if (mouse == null || !mouse.rightButton.isPressed)
                return;
            Vector2 delta = mouse.delta.ReadValue();
            yaw += delta.x * sensitivity;
            pitch -= delta.y * sensitivity;
            pitch = Mathf.Clamp(pitch, -89f, 89f);
            transform.localEulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }
}
