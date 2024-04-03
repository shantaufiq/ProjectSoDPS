using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName; // Nama scene berikutnya yang akan dimuat
    public float delayBeforeLoading = 5f; // Waktu tunda sebelum memuat scene berikutnya

    void Start()
    {
        // Memulai timer untuk memuat scene berikutnya setelah delay tertentu
        Invoke("LoadNextScene", delayBeforeLoading);
    }

    void LoadNextScene()
    {
        // Memuat scene berikutnya jika namanya tidak kosong
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}