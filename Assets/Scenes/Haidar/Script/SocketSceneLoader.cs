using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;

public class SocketSceneLoader : MonoBehaviour
{
    public int portNumber = 8888; // Port number to listen on
    public string nextSceneName; // Nama scene berikutnya yang akan dimuat setelah soket terisi

    private bool socketReady = false;
    private Socket listener;

    void Start()
    {
        StartListening();
    }

    void Update()
    {
        if (socketReady && listener.Poll(0, SelectMode.SelectRead))
        {
            byte[] buffer = new byte[1024];
            int bytesRead = listener.Receive(buffer);
            string data = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
            
            // Jika ada data yang diterima dari soket, pindah ke scene berikutnya
            if (!string.IsNullOrEmpty(data))
            {
                Debug.Log("Data received from socket: " + data);
                LoadNextScene();
            }
        }
    }

    void StartListening()
    {
        try
        {
            // Set up the listener socket
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, portNumber);
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(1);

            socketReady = true;
            Debug.Log("Socket listening on port " + portNumber);
        }
        catch (Exception e)
        {
            Debug.Log("Socket setup error: " + e.ToString());
        }
    }

    void LoadNextScene()
    {
        // Pindah ke scene berikutnya
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("No next scene specified!");
        }
    }

    void OnApplicationQuit()
    {
        // Tutup soket ketika aplikasi berhenti
        if (socketReady)
        {
            listener.Close();
            socketReady = false;
        }
    }
}

