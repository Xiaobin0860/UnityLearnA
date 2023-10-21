using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerC2 : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    const float MIN_SPAWN_INTERVAL = 3.0f;
    const float MAX_SPAWN_INTERVAL = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        var interval = Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL);
        Debug.Log("Start interval: " + interval);
        Invoke("SpawnRandomBall", interval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        var ballIndex = Random.Range(0, ballPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);

        // randomize spawn time
        var interval = Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL);
        Debug.Log("SpawnRandomBall interval: " + interval);
        Invoke("SpawnRandomBall", Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL));
    }

}
