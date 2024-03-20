using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatikanCanvasSetelahWaktu : MonoBehaviour
{
    public Canvas canvas; // Referensi ke Canvas yang ingin dimatikan
    public float waktuSebelumMatikan = 5f; // Waktu dalam detik sebelum mematikan Canvas

    void Start()
    {
        // Panggil fungsi MatikanCanvas setelah waktu tertentu
        Invoke("MatikanCanvas", waktuSebelumMatikan);
    }

    void MatikanCanvas()
    {
        // Pastikan canvas tidak null sebelum mematikan
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Canvas belum diatur!");
        }
    }
}

