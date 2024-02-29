using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT {
    public class HighlightController : MonoBehaviour
    {
        [SerializeField] private float transitionDuration = 1.0f; // Duration of the transition
        [SerializeField] private Material[] highlightMaterials; // The materials to highlight the object
        private Material[] originalMaterials; // The original materials of the object
        private Renderer objectRenderer; // The renderer of the object
        private bool isHighlighted = false; // Flag to track if the object is currently highlighted
        [SerializeField] private bool highlightOnStart = false; // Flag to track if the object should be highlighted on start
        private bool showNotif;
        private bool isHovering;

        private void Start()
        {
            if (highlightOnStart)
            {
                showNotif = true;
            }

            // Get the renderer component of the object
            objectRenderer = GetComponent<Renderer>();

            // Store the original materials
            originalMaterials = objectRenderer.materials;
        }

        private void Update()
        {
            if (showNotif) AutoHighlightAndUnhighlight();
        }

        public void StartAutoHighlight()
        {
            showNotif = true;
        }
         
        public void StopAutoHighlight()
        {
            showNotif = false;
        }

        private void AutoHighlightAndUnhighlight()
        {
            if (isHovering) return;

            // Calculate the duration for each state
            float totalDuration = transitionDuration * 2f;

            // Calculate the time since the script started
            float timeSinceStart = Time.time;

            // Calculate the remainder of division by the total duration
            float remainder = timeSinceStart % totalDuration;

            // If the remainder is less than the transition duration, highlight the object
            if (remainder < transitionDuration)
            {
                if (!isHighlighted)
                {
                    Highlight();
                }
            }
            else // If the remainder is greater than or equal to the transition duration, unhighlight the object
            {
                if (isHighlighted)
                {
                    Unhighlight();
                }
            }
        }

        public void HighlightInstant()
        {
            isHovering = true;
            objectRenderer.materials = highlightMaterials;
            StopAllCoroutines();
        }

        private void Highlight()
        {
            // Start the highlighting coroutine
            StartCoroutine(TransitionMaterials(highlightMaterials, originalMaterials));
            isHighlighted = true;
        }

        public void UnhighlightInstant()
        {
            isHovering = false;
            objectRenderer.materials = originalMaterials;
            StopAllCoroutines();
        }

        private void Unhighlight()
        {
            // Start the unhighlighting coroutine
            StartCoroutine(TransitionMaterials(originalMaterials, highlightMaterials));
            isHighlighted = false;
        }

        private IEnumerator TransitionMaterials(Material[] startMaterials, Material[] targetMaterials)
        {
            float elapsedTime = 0f;

            // Transition between materials
            while (elapsedTime < transitionDuration)
            {
                // Calculate the interpolation factor
                float t = elapsedTime / transitionDuration;

                // Interpolate between the start materials and the target materials
                Material[] lerpedMaterials = new Material[startMaterials.Length];
                for (int i = 0; i < startMaterials.Length; i++)
                {
                    lerpedMaterials[i] = new Material(startMaterials[i]);
                    lerpedMaterials[i].CopyPropertiesFromMaterial(targetMaterials[i]);
                    lerpedMaterials[i].Lerp(startMaterials[i], targetMaterials[i], t);
                }

                objectRenderer.materials = lerpedMaterials;

                // Increment the elapsed time
                elapsedTime += Time.deltaTime;
                yield return null; // Wait for the next frame
            }
        }
    }
}
