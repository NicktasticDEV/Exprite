using Extrite;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public SparrowRenderer sparrowRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sparrowRenderer = GetComponent<SparrowRenderer>();
    }

    void Start()
    {
        //sparrowRenderer.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sparrowRenderer.Play("Jump");
        }
        
    }


}
