using UnityEngine;
using Extrite;

[RequireComponent(typeof(SparrowRenderer))]
public class TestSpriteBF : MonoBehaviour
{
    private SparrowRenderer sparrowRenderer;

    void Awake()
    {
        sparrowRenderer = GetComponent<SparrowRenderer>();
    }

    void Start()
    {
        sparrowRenderer.Play("Idle");
    }

    void Update()
    {
        if (!sparrowRenderer.isPlaying)
        {
            sparrowRenderer.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparrowRenderer.Play("Cheer");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            sparrowRenderer.Play("Up");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            sparrowRenderer.Play("Down");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            sparrowRenderer.Play("Left");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            sparrowRenderer.Play("Right");
        }
    }
}
