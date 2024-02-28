using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PerencanaanPersiapanIoT
{
    public class HighlightUI : MonoBehaviour
    {
        public Color startColor;
        public Color targetColor;
        public float duration = 1f;
        public float delay = 0f;
        public int blinkCount = -1; // -1 untuk berkedip tanpa batas

        private Button button;
        private Image buttonImage;
        private Color originalColor;
        private LTDescr tween;
        private bool isBlinking = false; // Menandakan apakah animasi berkedip sedang berlangsung
        private int blinkCounter = 0;

        void Start()
        {
            button = GetComponent<Button>();
            buttonImage = button.image;
            originalColor = buttonImage.color; // Simpan warna asli tombol

            // Panggil fungsi Blink() setelah penundaan (jika ada)
            LeanTween.delayedCall(gameObject, delay, Blink);
        }

        void Blink()
        {
            // Set alpha ke 1 untuk startColor dan targetColor
            startColor = new Color(startColor.r, startColor.g, startColor.b, 1f);
            targetColor = new Color(targetColor.r, targetColor.g, targetColor.b, 1f);

            // Animasi berkedip menggunakan LeanTween
            tween = LeanTween.value(gameObject, startColor, targetColor, duration / 2f)
                .setOnUpdate((Color val) =>
                {
                    buttonImage.color = val; // Update warna tombol selama animasi
            })
                .setLoopPingPong(1) // Set loop agar animasi berkedip sekali saja
                .setOnComplete(OnBlinkComplete);

            isBlinking = true; // Set animasi sedang berlangsung
        }

        void OnBlinkComplete()
        {
            if (isBlinking && (blinkCount == -1 || blinkCounter < blinkCount))
            {
                blinkCounter++;
                LeanTween.delayedCall(gameObject, 0, Blink);
            }
            else
            {
                isBlinking = false; // Set animasi berhenti
            }
        }

        public void StopBlinking()
        {
            if (tween != null)
            {
                LeanTween.cancel(tween.id); // Hentikan animasi jika masih berjalan
                buttonImage.color = originalColor; // Kembalikan warna tombol ke warna aslinya
                isBlinking = false; // Set animasi berhenti
            }
        }
    }
}
