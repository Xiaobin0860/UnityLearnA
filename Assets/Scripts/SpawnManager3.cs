using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject barrierPrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    const float START_DELAY = 2.0f;
    const float SPAWN_INTERVAL = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBarrier", START_DELAY, SPAWN_INTERVAL);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnBarrier()
    {
        Instantiate(barrierPrefab, spawnPos, barrierPrefab.transform.rotation);
    }
}
