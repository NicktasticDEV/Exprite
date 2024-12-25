using Extrite;
using UnityEngine;

public class TestSprite : MonoBehaviour
{
    public SparrowRenderer sparrowRenderer;

    void Start()
    {
        StartCoroutine(sparrowRenderer.PlayAnimation("idle"));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparrowRenderer.Play("jump");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            sparrowRenderer.Play("wave");
        }

        if (!sparrowRenderer.isPlaying)
        {
            sparrowRenderer.Play("idle");
        }
    }
}
