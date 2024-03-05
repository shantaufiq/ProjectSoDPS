using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{
    public float moveDistance = 2f; // Jarak pergerakan objek
    public float moveSpeed = 2f; // Kecepatan pergerakan objek
    public bool moveUp = true; // Menentukan apakah objek akan bergerak ke atas atau ke bawah
    private Vector3 startPosition;
    private Vector3 endPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + Vector3.up * moveDistance; // Jika ingin bergerak ke bawah, gunakan Vector3.down
    }

    void Update()
    {
        if (moveUp)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.PingPong(Time.time * moveSpeed, 1));
        }
        else
        {
            transform.position = Vector3.Lerp(endPosition, startPosition, Mathf.PingPong(Time.time * moveSpeed, 1));
        }
    }
}

