using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    public GameObject trainPrefab;
    public float spawnInterval = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnTrain();
            timer = 0f;
        }
    }

    void SpawnTrain()
    {
        Instantiate(trainPrefab, transform.position, transform.rotation);
    }
}
