using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseObject : MonoBehaviour
{
    public Canvas canvas;

    private bool isHolding = false;
    private GameObject heldObject;

    void OnTriggerEnter(Collider other)
    {
        if (!isHolding && other.CompareTag("SocketAttach1"))
        {
            isHolding = true;
            heldObject = other.gameObject;
            heldObject.GetComponent<Rigidbody>().isKinematic = true; // Objek tidak jatuh saat dipegang
            canvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (isHolding && other.gameObject == heldObject)
        {
            isHolding = false;
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Objek dapat jatuh ke tanah setelah dilepas
            canvas.gameObject.SetActive(false);
        }
    }
}
