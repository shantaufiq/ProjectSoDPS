using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sandbox;
using UnityEngine.Events;
namespace PerencanaanPersiapanIoT
{
    public class AnimateHighlight : MonoBehaviour
    {
        public static AnimateHighlight instance;

        [System.Serializable]
        public struct contentFormat
        {
            public List<data> contentData;

            [System.Serializable]
            public struct data
            {
                public Sprite imageDisplayBackground;
                [Header("Button Component")]
                public Vector3 buttonPosition;
                public Vector3 buttonSize;
                [Header("Pop Up Component")]
                public Sprite imagePopUp;
                public Vector3 popUpPosition;
                public AnimatePingpong.MovementType myMovement;

            }
        }

        public List<contentFormat> contentManager;

        public int currentIndex = 0;
        [SerializeField] private List<contentFormat.data> stagingData;

        public GameObject[] ObjectToSetActive;
        public GameObject menuCanvas;
        public Image imageDisplay;
        public Button ButtonHighlight;

        [Header("External Assets")]
        [SerializeField] private AnimatePingpong popupAnimation;

        private bool canPressButton = true;
        public float cooldownTime = 1.0f; // Waktu cooldown dalam detik

        [Header("Check Data")]
        public bool isArduinoIoT;

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            currentIndex = 0;
            //UpdateImageAndPosition();
        }

        public void ObjectToSetActiveState(bool isActive)
        {

            foreach (var item in ObjectToSetActive)
            {
                item.SetActive(isActive);
            }

            menuCanvas.SetActive(!isActive);
        }

        public void OnClickShowContent(int _index)
        {
            for (int i = 0; i < contentManager[_index].contentData.Count; i++)
            {
                stagingData.Add(contentManager[_index].contentData[i]);
            }

            ObjectToSetActiveState(true);
            PrintDataToCanvas();
        }

        public void PrintDataToCanvas()
        {
            if (stagingData[currentIndex].imageDisplayBackground == null) return;

            popupAnimation.StopAnimate();

            if (currentIndex >= 0 && currentIndex < stagingData.Count)
            {
                // mengganti gambar
                imageDisplay.sprite = stagingData[currentIndex].imageDisplayBackground;

                popupAnimation.SetDescriptionBtn(stagingData[currentIndex].imagePopUp, stagingData[currentIndex].popUpPosition, stagingData[currentIndex].myMovement);

                // mengganti posisi tombol
                ButtonHighlight.transform.localPosition = stagingData[currentIndex].buttonPosition;

                //// mengatur ukuran tombol
                ButtonHighlight.GetComponent<RectTransform>().sizeDelta = stagingData[currentIndex].buttonSize;
            }
            else
            {
                Debug.LogError("Index out of range!");
            }
        }

        public void OnButtonPressed()
        {
            if (currentIndex >= stagingData.Count - 1)
            {
                stagingData.Clear();
                currentIndex = 0;
                ObjectToSetActiveState(false);
                return;
            }

            if (canPressButton)
            {
                currentIndex = (currentIndex + 1);

                PrintDataToCanvas();

                // Mengatur cooldown
                StartCoroutine(ButtonCooldown());
            }
        }

        // Method untuk cooldown tombol
        private IEnumerator ButtonCooldown()
        {
            canPressButton = false;
            yield return new WaitForSeconds(cooldownTime);
            canPressButton = true;
        }
    }
}
