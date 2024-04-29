using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public Canvas popupCanvas;
    public float closeDelay = 3f; // Waktu penundaan sebelum menutup pop-up (dalam detik)
    private float timer = 0f;
    private bool isPopupOpen = false;

    void Update()
    {
        // Periksa apakah pop-up sedang terbuka
        if (popupCanvas.enabled && !isPopupOpen)
        {
            isPopupOpen = true;
            timer = 0f;
        }

        // Hitung waktu yang berlalu jika pop-up terbuka
        if (isPopupOpen)
        {
            timer += Time.deltaTime;

            // Tutup pop-up setelah penundaan tertentu
            if (timer >= closeDelay)
            {
                ClosePopupCanvas();
            }
        }
    }

    // Fungsi untuk menutup pop-up
    void ClosePopupCanvas()
    {
        popupCanvas.enabled = false;
        isPopupOpen = false;
        timer = 0f;
    }
}
