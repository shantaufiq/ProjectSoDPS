using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAreaGuide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Disable the player area guide
            gameObject.SetActive(false);
        }
    }
}
