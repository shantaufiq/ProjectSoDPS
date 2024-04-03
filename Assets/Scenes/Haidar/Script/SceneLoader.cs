using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName; // Nama scene berikutnya yang akan dimuat
    public float delayBeforeLoading = 5f; // Waktu tunda sebelum memuat scene berikutnya

    private AudioSource[] audioSources; // Array untuk menyimpan semua komponen AudioSource di scene

    void Start()
    {
        // Memperoleh semua komponen AudioSource di scene
        audioSources = FindObjectsOfType<AudioSource>();

        // Memulai timer untuk memuat scene berikutnya setelah delay tertentu
        Invoke("LoadNextScene", delayBeforeLoading);
    }

    void LoadNextScene()
    {
        // Mematikan semua audio di scene sebelum memuat scene berikutnya
        foreach (var audioSource in audioSources)
        {
            audioSource.Stop();
        }

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
