using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextImageButton : MonoBehaviour
{
    public Sprite[] images; // Array untuk menyimpan gambar-gambar yang akan ditampilkan
    public Image imageDisplay; // Referensi ke komponen Image untuk menampilkan gambar

    private int currentImageIndex = 0; // Indeks gambar saat ini

    void Start()
    {
        // Menampilkan gambar pertama saat game dimulai
        DisplayImage(currentImageIndex);
    }

    // Method untuk menampilkan gambar pada indeks tertentu
    void DisplayImage(int index)
    {
        // Pastikan indeks berada dalam rentang array
        if (index >= 0 && index < images.Length)
        {
            imageDisplay.sprite = images[index]; // Mengatur sprite pada komponen Image
        }
    }

    // Method untuk menampilkan gambar berikutnya
    public void ShowNextImage()
    {
        currentImageIndex++; // Meningkatkan indeks
        if (currentImageIndex >= images.Length)
        {
            // Jika sudah mencapai akhir array, kembali ke gambar pertama
            currentImageIndex = 0;
        }
        DisplayImage(currentImageIndex); // Menampilkan gambar pada indeks yang baru
    }
}
