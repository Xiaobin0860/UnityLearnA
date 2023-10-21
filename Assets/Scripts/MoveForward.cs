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
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
            return;
        }
        else if (transform.position.z < bottomBound || transform.position.x > 20 || transform.position.x < -20)
        {
            Destroy(gameObject);
            var ctrl = GameObject.Find("Human").GetComponent<HumanController>();
            if (ctrl.lives > 0)
            {
                ctrl.lives -= 1;
                if (ctrl.lives == 0)
                {
                    Debug.Log("Game Over!");
                }
                else
                {
                    Debug.Log("Lives: " + ctrl.lives);
                }
            }
            return;
        }
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
