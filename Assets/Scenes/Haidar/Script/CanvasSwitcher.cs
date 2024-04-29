using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvasToActivate; // Canvas yang akan diaktifkan
    public Canvas canvasToDeactivate; // Canvas yang akan dinonaktifkan

    // Metode untuk mengaktifkan satu canvas dan menonaktifkan canvas lainnya
    public void SwitchCanvas()
    {
        if (canvasToDeactivate != null)
            canvasToDeactivate.gameObject.SetActive(false); // Menonaktifkan canvas yang ditentukan

        if (canvasToActivate != null)
            canvasToActivate.gameObject.SetActive(true); // Mengaktifkan canvas yang ditentukan
    }
}
