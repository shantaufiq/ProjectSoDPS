using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketController : MonoBehaviour
{
    public GameObject socketedObject; // Objek yang akan ditempatkan di dalam socket
    public Canvas canvasToDeactivate; // Canvas yang akan dinonaktifkan jika objek ditempatkan di dalam socket

    private void OnTriggerEnter(Collider other)
    {
        // Pastikan objek yang masuk adalah objek yang diinginkan
        if (other.gameObject == socketedObject)
        {
            // Menonaktifkan canvas
            canvasToDeactivate.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Pastikan objek yang keluar adalah objek yang diinginkan
        if (other.gameObject == socketedObject)
        {
            // Mengaktifkan kembali canvas
            canvasToDeactivate.gameObject.SetActive(true);
        }
    }
}
