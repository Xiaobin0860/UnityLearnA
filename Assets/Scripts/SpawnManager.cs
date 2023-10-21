using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10;
    private float spawnPosZ = 20;
    private float spawnPosL = -20;
    private float spawnPosR = 20;
    private float spawnTop = 15;
    private float spawnBottom = 5;

    const float START_DELAY = 2.0f;
    const float SPAWN_INTERVAL = 1.5f;
    const float MIN_SPAWN_INTERVAL = 3.0f;
    const float MAX_SPAWN_INTERVAL = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", START_DELAY, SPAWN_INTERVAL);
        Invoke("SpawnRandomAnimalLeft", Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL));
        Invoke("SpawnRandomAnimalRight", Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL));
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal()
    {
        var animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    void SpawnRandomAnimalLeft()
    {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(spawnPosL, 0, Random.Range(-spawnRangeX, spawnRangeX));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.LookRotation(Vector3.right));

        Invoke("SpawnRandomAnimalLeft", Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL));
    }

    void SpawnRandomAnimalRight()
    {
        var animalIndex = Random.Range(0, animalPrefabs.Length);
        var spawnPos = new Vector3(spawnPosR, 0, Random.Range(spawnBottom, spawnTop));
        Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.LookRotation(Vector3.left));

        Invoke("SpawnRandomAnimalRight", Random.Range(MIN_SPAWN_INTERVAL, MAX_SPAWN_INTERVAL));
    }
}
