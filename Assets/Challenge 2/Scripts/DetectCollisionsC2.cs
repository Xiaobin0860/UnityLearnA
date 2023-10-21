using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsC2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
