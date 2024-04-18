using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT
{
    public class BoneCableController : MonoBehaviour
    {
        [SerializeField] private CableController cableController;
        public CableController CableController { get => cableController; set => cableController = value; }

        private Camera mainCamera;
        [SerializeField] private Canvas canvasTag;
        private bool isTagSelected = false;

        //Container for the detection cubes where it will be used to check if the cable is connected to the correct socket
        private List<GameObject> detectionCubes; 

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            // Ensure the main camera is found
            if (mainCamera != null && canvasTag != null)
            {
                // Get the target rotation towards the camera
                Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.forward, Vector3.up);

                // Constrain the rotation to only rotate around the Y-axis
                targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

                // Apply the rotation to the image
                canvasTag.gameObject.transform.rotation = targetRotation;
            }
        }

        public void ShowTag()
        {
            if (isTagSelected == true) return;
            canvasTag.gameObject.SetActive(true);
        }

        public void HideTag()
        {
            canvasTag.gameObject.SetActive(false);
        }

        public void TagSelected()
        {
            isTagSelected = !isTagSelected;
            if (isTagSelected == true)
            {
                HideTag();
            }
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Pin Socket"))
            {
                var cableValidator = collision.gameObject.GetComponent<CableValidator>();

                if (detectionCubes.Count == 0 || detectionCubes == null)
                {
                    detectionCubes.Add(cableValidator.detectionCube);
                    detectionCubes[0].SetActive(true);
                }
                else
                {
                    detectionCubes.Add(cableValidator.detectionCube);
                }
            }
        }

        public void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Pin Socket"))
            {
                var cableValidator = collision.gameObject.GetComponent<CableValidator>();

                if (detectionCubes.Contains(cableValidator.detectionCube) && detectionCubes.Count > 1)
                {
                    detectionCubes.Remove(cableValidator.detectionCube);
                    cableValidator.detectionCube.SetActive(false);
                    detectionCubes[0].SetActive(true);
                }
                else if (detectionCubes.Contains(cableValidator.detectionCube) && detectionCubes.Count == 1)
                {
                    detectionCubes.Remove(cableValidator.detectionCube);
                    cableValidator.detectionCube.SetActive(false);
                }
            }
        }
    }
}
