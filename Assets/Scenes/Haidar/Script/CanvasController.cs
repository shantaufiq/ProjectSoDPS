using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController  : MonoBehaviour
{
    // References to the two canvases
    public Canvas canvas1;
    public Canvas canvas2;

    // References to the two canvases to activate
    public Canvas canvasToActivate1;
    public Canvas canvasToActivate2;

    private void Update()
    {
        // Check if both canvas1 and canvas2 are active
        if (canvas1.gameObject.activeSelf && canvas2.gameObject.activeSelf)
        {
            // Activate the target canvases
            if (canvasToActivate1 != null)
            {
                canvasToActivate1.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No canvas to activate 1 assigned!");
            }

            if (canvasToActivate2 != null)
            {
                canvasToActivate2.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No canvas to activate 2 assigned!");
            }
        }
        else
        {
            // Deactivate the target canvases if any of the two canvases is inactive
            if (canvasToActivate1 != null)
            {
                canvasToActivate1.gameObject.SetActive(false);
            }

            if (canvasToActivate2 != null)
            {
                canvasToActivate2.gameObject.SetActive(false);
            }
        }
    }
}

