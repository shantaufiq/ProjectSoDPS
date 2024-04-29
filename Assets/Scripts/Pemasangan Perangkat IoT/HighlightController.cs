using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InstalasiIoT {
    public class HighlightController : MonoBehaviour
    {
        public Color targetColor = Color.yellow;
        public float transitionDuration = 1f;

        private Material[] originalMaterials;
        private bool isHighlighting = false;
        private Renderer objectRenderer;
        [SerializeField] private bool highlightOnStart;

        void Start()
        {
            // Store the original materials of the object
            objectRenderer = GetComponent<Renderer>();
            originalMaterials = objectRenderer.materials;
            if (highlightOnStart)
            {
                StartHighlight();
            }
        }

        public void StartHighlight()
        {
            if (!isHighlighting)
            {
                // Start highlighting coroutine
                isHighlighting = true;
                StartCoroutine(HighlightCoroutine());
            }
        }

        public void StopHighlight()
        {
            if (isHighlighting)
            {
                // Stop highlighting
                isHighlighting = false;
                StopAllCoroutines();

                // Revert materials to original colors immediately
                objectRenderer.materials = originalMaterials;
            }
        }

        IEnumerator HighlightCoroutine()
        {
            while (true)
            {
                // Highlight the object
                float t = 0f;
                while (t < 1f)
                {
                    t += Time.deltaTime / transitionDuration;
                    Color[] lerpedColors = new Color[originalMaterials.Length];
                    for (int i = 0; i < originalMaterials.Length; i++)
                    {
                        lerpedColors[i] = Color.Lerp(originalMaterials[i].color, targetColor, t);
                    }
                    objectRenderer.materials = GetMaterialsCopy(lerpedColors);
                    yield return null;
                }

                // Wait for a short duration
                yield return new WaitForSeconds(0.5f);

                // Revert to original materials
                t = 0f;
                while (t < 1f)
                {
                    t += Time.deltaTime / transitionDuration;
                    Color[] lerpedColors = new Color[originalMaterials.Length];
                    for (int i = 0; i < originalMaterials.Length; i++)
                    {
                        lerpedColors[i] = Color.Lerp(targetColor, originalMaterials[i].color, t);
                    }
                    objectRenderer.materials = GetMaterialsCopy(lerpedColors);
                    yield return null;
                }

                // Check if highlighting should continue
                if (!isHighlighting)
                    break;
            }
        }

        // Utility method to copy the materials array
        private Material[] GetMaterialsCopy(Color[] colors)
        {
            Material[] materialsCopy = new Material[originalMaterials.Length];
            for (int i = 0; i < originalMaterials.Length; i++)
            {
                materialsCopy[i] = new Material(originalMaterials[i]);
                materialsCopy[i].color = colors[i];
            }
            return materialsCopy;
        }
    }
}
