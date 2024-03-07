using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PerencanaanPersiapanIoT
{
    public class AnimateHighlight : MonoBehaviour
    {
        [System.Serializable]
        public struct ListImage
        {
            public Sprite imageDisplayList; // Menggunakan Sprite pada Background
            public Sprite imageButton;
            public Vector3 posisiButton;
            public float Width;
            public float height;
            public movementType myMovement;
            public enum movementType
            {
                leftToRight, rightToLeft
            }
        }

        public List<ListImage> listImage;
        public Image imageDisplay;
        public Button ButtonHighlight;

        private int currentIndex = 0;
        private bool canPressButton = true;
        public float cooldownTime = 1.0f; // Waktu cooldown dalam detik

        private void Start()
        {
            currentIndex = 0;
            // Set gambar dan posisi tombol untuk indeks awal
            UpdateImageAndPosition();
        }

        // Method untuk mengganti gambar dan posisi tombol berdasarkan indeks
        private void UpdateImageAndPosition()
        {
            if (listImage[currentIndex].imageDisplayList == null) return;

            if (currentIndex >= 0 && currentIndex < listImage.Count)
            {
                // Mengganti gambar
                imageDisplay.sprite = listImage[currentIndex].imageDisplayList;



                //// Mengganti posisi tombol
                //ButtonHighlight.transform.localPosition = listImage[currentIndex].posisiButton;

                //// Mengatur ukuran tombol
                //ButtonHighlight.GetComponent<RectTransform>().sizeDelta = listImage[currentIndex].buttonSize;
            }
            else
            {
                Debug.LogError("Index out of range!");
            }
        }

        // Method untuk menangani ketika tombol ditekan
        public void OnButtonPressed()
        {
            if (canPressButton)
            {
                // Tingkatkan indeks dan pastikan tetap dalam rentang yang valid
                currentIndex = (currentIndex + 1) % listImage.Count;
                // Update gambar dan posisi tombol sesuai dengan indeks baru
                UpdateImageAndPosition();

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
