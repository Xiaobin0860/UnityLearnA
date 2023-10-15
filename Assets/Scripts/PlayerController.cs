using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float turnSpeed = 45f;

    public GameObject camera1;
    public GameObject camera2;

    public string playerTag = "P1";

    void Awake()
    {
        camera1.SetActive(true);
        camera2.SetActive(true);//加载对象以初始化 offset
        camera2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal" + playerTag);
        var verticalInput = Input.GetAxis("Vertical" + playerTag);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwichCamera();
        }
    }

    void SwichCamera()
    {
        if (camera1.activeSelf)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        else
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
    }
}
