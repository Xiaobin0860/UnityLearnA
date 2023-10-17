using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40;

    public float topBound = 30;
    public float bottomBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < bottomBound) {
            Destroy(gameObject);
        }
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
