using UnityEngine;

public class GameObjectActivator : MonoBehaviour
{
    // Event yang akan dipicu saat objek diaktifkan
    public delegate void GameObjectActivated(GameObject activatedObject);
    public static event GameObjectActivated OnGameObjectActivated;

    // Array untuk menyimpan informasi apakah objek sudah diaktifkan
    private bool[] activatedObjects;

    // Fungsi untuk menginisialisasi array
    void Awake()
    {
        // Inisialisasi array dengan panjang sejumlah jumlah objek yang ingin diaktifkan sekali
        activatedObjects = new bool[transform.childCount];
    }

    // Fungsi yang akan dipanggil ketika objek diaktifkan
    void OnEnable()
    {
        // Periksa apakah objek telah diaktifkan sebelumnya
        if (!HasActivated())
        {
            // Panggil event saat objek diaktifkan untuk pertama kali
            TriggerEvent();

            // Tandai objek sebagai diaktifkan
            MarkAsActivated();
        }
    }

    // Fungsi untuk memeriksa apakah ada objek yang sudah diaktifkan
    private bool HasActivated()
    {
        foreach (bool activated in activatedObjects)
        {
            if (activated)
            {
                return true;
            }
        }
        return false;
    }

    // Fungsi untuk memicu event
    private void TriggerEvent()
    {
        // Periksa apakah event memiliki subscriber (listener)
        if (OnGameObjectActivated != null)
        {
            // Panggil event, mengirimkan referensi objek yang diaktifkan
            OnGameObjectActivated(gameObject);
        }
    }

    // Fungsi untuk menandai objek sebagai sudah diaktifkan
    private void MarkAsActivated()
    {
        // Temukan indeks pertama dari objek yang belum diaktifkan
        int index = 0;
        for (int i = 0; i < activatedObjects.Length; i++)
        {
            if (!activatedObjects[i])
            {
                index = i;
                break;
            }
        }

        // Tandai objek sebagai diaktifkan
        activatedObjects[index] = true;
    }
}
