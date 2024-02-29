using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MediaSlide : MonoBehaviour
{
    public List<Sprite> images; // List gambar yang akan ditampilkan
    public Image displayImage; // Komponen Image untuk menampilkan gambar
    public Button nextButton; // Tombol next
    public Button prevButton; // Tombol prev

    private int currentIndex = 0; // Indeks gambar saat ini

    void Start()
    {
        // Memastikan ada gambar yang ditetapkan untuk ditampilkan
        if (images.Count > 0)
        {
            // Menampilkan gambar pertama di awal
            displayImage.sprite = images[currentIndex];
            UpdateButtonInteractability(); // Memperbarui keadaan interaktif tombol
        }
    }

    public void ShowNextImage()
    {
        // Mengecek apakah masih ada gambar berikutnya di dalam list
        if (currentIndex < images.Count - 1)
        {
            currentIndex++;
            displayImage.sprite = images[currentIndex];
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
}
