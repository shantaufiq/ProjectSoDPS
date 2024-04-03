using UnityEngine;

public class MeshFaderTransition : MonoBehaviour
{
    // Material yang akan digunakan untuk menggantikan material asli.
    public Material[] fadeMaterials;

    // Referensi ke material asli objek.
    private Material[] originalMaterials;
    private Renderer objRenderer;

    public float fadeDuration = 2f;
    public float delayBeforeStarting = 0f;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        // Menyimpan material asli dari objek.
        if (objRenderer != null)
        {
            originalMaterials = objRenderer.materials;
        }

        //SetActiveWithFader(false); //? call setactive gameobject
    }

    public void SetActiveWithFader(bool condition)
    {
        if (condition)
            //! is unestablished feature
            RestoreOriginalMaterials();
        else
        {
            ReplaceMaterialWithHoverMaterial();

            SetMaterialAlpha();
        }
    }

    private void SetMaterialAlpha()
    {
        LeanTween.alpha(this.gameObject, 0, fadeDuration)
                .setDelay(delayBeforeStarting)
                .setEase(LeanTweenType.easeInOutQuad);
                //.setOnComplete(() => Destroy(this.gameObject));
    }

    private void ReplaceMaterialWithHoverMaterial()
    {
        if (objRenderer != null && fadeMaterials != null && fadeMaterials.Length == originalMaterials.Length)
        {
            Material[] materialsToApply = new Material[fadeMaterials.Length];
            for (int i = 0; i < fadeMaterials.Length; i++)
            {
                materialsToApply[i] = fadeMaterials[i] != null ? fadeMaterials[i] : originalMaterials[i];
            }
            objRenderer.materials = materialsToApply;
        }
    }

    //! is unestablished feature
    private void RestoreOriginalMaterials()
    {
        if (objRenderer != null && originalMaterials != null)
        {
            objRenderer.materials = originalMaterials;
        }
    }
}
