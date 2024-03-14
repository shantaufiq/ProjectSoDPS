using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextCanvasButton : MonoBehaviour
{
    public GameObject[] canvases; // Array untuk menyimpan canvas yang akan ditampilkan
    private int currentCanvasIndex = 0; // Indeks canvas saat ini

    void Start()
    {
        // Menampilkan canvas pertama saat game dimulai
        ShowCanvas(currentCanvasIndex);
    }

    // Method untuk menampilkan canvas pada indeks tertentu
    void ShowCanvas(int index)
    {
        // Pastikan indeks berada dalam rentang array
        if (index >= 0 && index < canvases.Length)
        {
            // Menyembunyikan semua canvas
            foreach (GameObject canvas in canvases)
            {
                canvas.SetActive(false);
            }

            // Menampilkan canvas pada indeks yang dipilih
            canvases[index].SetActive(true);
        }
    }

    // Method untuk menampilkan canvas selanjutnya
    public void ShowNextCanvas()
    {
        currentCanvasIndex++; // Meningkatkan indeks
        if (currentCanvasIndex >= canvases.Length)
        {
            // Jika sudah mencapai akhir array, kembali ke canvas pertama
            currentCanvasIndex = 0;
        }
        ShowCanvas(currentCanvasIndex); // Menampilkan canvas pada indeks yang baru
    }
}

