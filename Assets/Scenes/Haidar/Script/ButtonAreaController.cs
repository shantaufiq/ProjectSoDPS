using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonAreaController : MonoBehaviour
{
    public GameObject areaToActivate; // Area yang akan diaktifkan saat tombol diklik

    public void ActivateAreaOnClick()
    {
        if (areaToActivate != null)
        {
            areaToActivate.SetActive(true); // Mengaktifkan area saat tombol diklik
        }
        else
        {
            Debug.LogError("Area to activate is not assigned!");
        }
    }
}
