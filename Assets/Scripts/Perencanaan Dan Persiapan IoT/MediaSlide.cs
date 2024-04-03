namespace PerencanaanPersiapanIoT
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    namespace PerencanaanPersiapanIoT
    {
        public class MediaSlide : MonoBehaviour
        {
            public List<Sprite> images; // List gambar yang akan ditampilkan
            public Image displayImage; // Komponen Image untuk menampilkan gambar
            public Button nextButton; // Tombol next
            public Button prevButton; // Tombol prev
            public List<Image> carouselIndicators; // List indikator bola-bola carousel
            private int currentIndex = 0; // Indeks gambar saat ini
            public UnityEvent slideComplete;
            public UnityEvent resetSlide;

            private bool activeEvent;

            void Start()
            {
                // Memastikan ada gambar yang ditetapkan untuk ditampilkan
                if (images.Count > 0)
                {
                    // Menampilkan gambar pertama di awal
                    displayImage.sprite = images[currentIndex];
                    UpdateButtonInteractability(); // Memperbarui keadaan interaktif tombol
                    UpdateIndicators(); // Memperbarui penanda bola-bola
                    activeEvent = true;
                }
            }

            public void ResetSlide()
            {
                currentIndex = 0; // Reset indeks gambar ke 0
                displayImage.sprite = images[currentIndex]; // Tampilkan gambar pertama dari list
                UpdateIndicators(); // Memperbarui penanda bola-bola
                UpdateButtonInteractability(); // Memperbarui keadaan interaktif tombol
                slideComplete.RemoveAllListeners();
                activeEvent = false;
            }

            public void ShowNextImage()
            {
                // Mengecek apakah masih ada gambar berikutnya di dalam list
                if (currentIndex < images.Count - 1)
                {
                    currentIndex++;
                    displayImage.sprite = images[currentIndex];
                    UpdateIndicators(); // Memperbarui penanda bola-bola
                }

                if (currentIndex == images.Count - 1 && activeEvent)
                {
                    slideComplete.Invoke();
                }if (currentIndex == images.Count - 1)
                {
                    resetSlide.Invoke();
                }
                // Memperbarui keadaan interaktif tombol setelah menampilkan gambar yang baru
                UpdateButtonInteractability();
            }

            public void ShowPreviousImage()
            {
                // Mengecek apakah masih ada gambar sebelumnya di dalam list
                if (currentIndex > 0)
                {
                    currentIndex--;
                    displayImage.sprite = images[currentIndex];
                    UpdateIndicators(); // Memperbarui penanda bola-bola
                }

                // Memperbarui keadaan interaktif tombol setelah menampilkan gambar yang baru
                UpdateButtonInteractability();
            }

            private void UpdateButtonInteractability()
            {
                // Menonaktifkan tombol next jika sudah mencapai gambar terakhir
                nextButton.interactable = currentIndex < images.Count - 1;

                // Menonaktifkan tombol prev jika sudah berada pada gambar pertama
                prevButton.interactable = currentIndex > 0;
            }

            private void UpdateIndicators()
            {
                // Mengatur warna penanda bola-bola sesuai dengan indeks slide saat ini
                for (int i = 0; i < carouselIndicators.Count; i++)
                {
                    // Jika indeks sesuai, atur warna bola menjadi putih (atau sesuai yang diinginkan)
                    if (i == currentIndex)
                        carouselIndicators[i].color = Color.white;
                    // Jika tidak sesuai, atur warna bola menjadi warna lain (atau sesuai yang diinginkan)
                    else
                        carouselIndicators[i].color = Color.grey; // Contoh warna abu-abu untuk bola yang tidak aktif
                }
            }
        }
    }

}
