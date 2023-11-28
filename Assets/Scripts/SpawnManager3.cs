using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos = new Vector3(50, 0, 0);
    const float START_DELAY = 2.0f;
    const float SPAWN_INTERVAL = 1.5f;
    private PlayerController3 playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
        InvokeRepeating("SpawnBarrier", START_DELAY, SPAWN_INTERVAL);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnBarrier()
    {
        if (playerControllerScript.isGameOver)
        {
            CancelInvoke("SpawnBarrier");
        }
        else
        {
            var barrierIndex = Random.Range(0, obstaclePrefabs.Length);
            var obstacle = obstaclePrefabs[barrierIndex];
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
