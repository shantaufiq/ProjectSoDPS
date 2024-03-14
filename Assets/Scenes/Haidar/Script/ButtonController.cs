using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonController : MonoBehaviour
{
    public List<Canvas> canvasList;
    private int currentCanvasIndex = 0;

    private void Start()
    {
        // Menampilkan canvas pertama dan menyembunyikan sisanya saat permainan dimulai
        ShowCanvas(currentCanvasIndex);
    }

    public void OnButtonClick()
    {
        // Menyembunyikan canvas saat tombol diklik
        HideCanvas(currentCanvasIndex);

        // Mengupdate index untuk beralih ke canvas berikutnya
        currentCanvasIndex = (currentCanvasIndex + 1) % canvasList.Count;

        // Menampilkan canvas berikutnya
        ShowCanvas(currentCanvasIndex);
    }

    private void ShowCanvas(int index)
    {
        // Menampilkan canvas sesuai dengan indeks yang diberikan
        canvasList[index].gameObject.SetActive(true);
    }

    private void HideCanvas(int index)
    {
        // Menyembunyikan canvas sesuai dengan indeks yang diberikan
        canvasList[index].gameObject.SetActive(false);
    }
}
