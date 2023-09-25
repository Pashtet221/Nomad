using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [System.Serializable]
    public class ObjectInfo
    {
        public GameObject objectPrefab; // The prefab of the object to spawn
        public Transform spawnPoint;    // The spawn point where objects will appear
        public float spawnInterval = 3f; // Time interval between spawns
        public float objectLifetime = 5f; // Time before the spawned object is destroyed
        public float spawnRadius = 2f;   // The radius around spawnPoint for random spawning
    }

    public ObjectInfo[] objects;
    private float timeSinceLastSpawn;

    private void Start()
    {
        timeSinceLastSpawn = objects[0].spawnInterval; // Initial delay before first spawn
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= objects[0].spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f; // Reset the timer
        }
    }

    private void SpawnObject()
    {
        foreach (ObjectInfo objInfo in objects)
        {
            // Calculate a random offset within the spawnRadius
            Vector2 randomOffset = Random.insideUnitCircle * objInfo.spawnRadius;

            // Set the spawn position around the spawnPoint with the random offset
            Vector3 spawnPosition = objInfo.spawnPoint.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

            GameObject newObject = Instantiate(objInfo.objectPrefab, spawnPosition, Quaternion.identity);
            Rigidbody2D rb = newObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.simulated = true; // Enable physics simulation for the spawned object
            }

            Destroy(newObject, objInfo.objectLifetime); // Destroy the object after the set lifetime
        }
    }
}
