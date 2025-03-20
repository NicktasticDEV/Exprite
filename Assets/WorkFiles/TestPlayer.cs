using Exprite;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public ExpriteRenderer sparrowRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        sparrowRenderer = GetComponent<ExpriteRenderer>();
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
