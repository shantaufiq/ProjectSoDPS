using UnityEngine;

namespace InstalasiIoT
{
    public class BoneCableController : MonoBehaviour
    {
        [SerializeField] private CableController cableController;
        public CableController CableController { get => cableController; set => cableController = value; }

        private Camera mainCamera;
        [SerializeField] private Canvas canvasTag;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            // Ensure the main camera is found
            if (mainCamera != null)
            {
                // Get the target rotation towards the camera
                Quaternion targetRotation = Quaternion.LookRotation(mainCamera.transform.forward, Vector3.up);

                // Constrain the rotation to only rotate around the Y-axis
                targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

                // Apply the rotation to the image
                canvasTag.gameObject.transform.rotation = targetRotation;
            }
            else
            {
                // If the main camera is not found, disable the image
                canvasTag.gameObject.SetActive(false);
            }
        }

        public void ShowTag()
        {
            canvasTag.gameObject.SetActive(true);
        }

        public void HideTag()
        {
            canvasTag.gameObject.SetActive(false);
        }
    }
}
