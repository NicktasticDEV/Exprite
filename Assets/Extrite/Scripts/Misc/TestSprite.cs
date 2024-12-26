using Extrite;
using UnityEngine;

public class TestSprite : MonoBehaviour
{
    public SparrowRenderer sparrowRenderer;

    void Start()
    {
        sparrowRenderer.Play("idle");
    }

    void Update()
    {
        // Check if W key is pressed
        if (Input.GetKeyDown(KeyCode.W))
        {
            sparrowRenderer.Play("wave");
        }

        // Check if Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparrowRenderer.Play("jump");
        }

        if (!sparrowRenderer.isPlaying)
        {
            sparrowRenderer.Play("idle");
        }
        
    }
}