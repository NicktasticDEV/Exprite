using UnityEngine;

public class SkewMatrixTest : MonoBehaviour
{
    public float shearFactorX = 0.0f; // Shear factor for horizontal skew
    public float shearFactorY = 0.0f; // Shear factor for vertical skew

    private SpriteRenderer spriteRenderer;
    private Material material;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
    }

    void Update()
    {
        material.SetFloat("_ShearX", shearFactorX);
        material.SetFloat("_ShearY", shearFactorY);
    }
}