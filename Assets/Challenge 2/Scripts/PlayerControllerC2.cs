using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerC2 : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool canShoot = true;
    private float shootInterval = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = false;
            Invoke("RestShoot", shootInterval);
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }

    void RestShoot() => canShoot = true;
}
