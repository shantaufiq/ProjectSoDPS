using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class AreaPoint : MonoBehaviour
    {
        private Camera mainCamera;

        void Start()
        {
            // Find the main camera in the scene
            mainCamera = Camera.main;
        }

        void LateUpdate()
        {
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
