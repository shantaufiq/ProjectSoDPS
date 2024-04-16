using UnityEngine;

namespace InstalasiIoT
{
    public class AnimatedPointer : MonoBehaviour
    {
        private Camera mainCamera;
        public float movementDistance = 1f;
        public float movementSpeed = 1f;

        void Start()
        {
            // Find the main camera in the scene
            mainCamera = Camera.main;

            // Start the movement animation
            AnimateMovement();
        }

        void AnimateMovement()
        {
            // Move the image up and down using LeanTween
            LeanTween.moveY(gameObject, movementDistance, movementSpeed)
                .setLoopPingPong();
        }

        void LateUpdate()
        {
            // Ensure the main camera is found
            if (mainCamera == null)
            {
                // If the main camera is not found, disable the image
                gameObject.SetActive(false);
                return; // Exit the function early
            }

            // Calculate the rotation towards the camera
            Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.forward, Vector3.up);

            // Constrain the rotation to only rotate around the Y-axis
            targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

            // Apply the rotation to the object's forward direction
            transform.forward = mainCamera.transform.forward;
        }
    }
}
