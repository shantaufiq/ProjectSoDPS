using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class AreaPointer : MonoBehaviour
    {
        private Camera mainCamera;
        public float movementDistance = 1f;
        public float movementSpeed = 1f;
        private Vector3 startPos;

        void Start()
        {
            // Find the main camera in the scene
            mainCamera = Camera.main;

            // Store the starting position
            startPos = transform.position;
        }

        void LateUpdate()
        {
            // Move the image up and down
            float newY = startPos.y + Mathf.Sin(Time.time * movementSpeed) * movementDistance;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Ensure the main camera is found
            if (mainCamera != null)
            {
                // Get the target rotation towards the camera
                Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.forward, Vector3.up);

                // Constrain the rotation to only rotate around the Y-axis
                targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

                // Apply the rotation to the image
                transform.rotation = targetRotation;
            }
            else
            {
                // If the main camera is not found, disable the image
                gameObject.SetActive(false);
            }
        }
    }
}
