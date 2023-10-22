using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    void Start()
    {
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one * 2.5f;

        Material material = Renderer.material;

        material.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
    }

    void Update()
    {
        transform.Rotate(20.0f * Time.deltaTime, 10.0f * Time.deltaTime, 0.0f);
    }
}
