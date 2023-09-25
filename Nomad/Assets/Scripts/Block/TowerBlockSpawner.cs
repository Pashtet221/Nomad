using UnityEngine;

public class TowerBlockSpawner : MonoBehaviour
{
    public static TowerBlockSpawner Instance {get; private set;}

    public GameObject blockPrefab;   // The prefab of the tower block
    public Transform spawnPoint;     // The spawn point for the blocks
    public float spawnDelay = 2f;    // Time delay before spawning after mouse press

    private bool isMousePressed = false;
    private float timePressed = 0f;
    private bool canSpawnBlocks = true; // Flag to control block spawning

    private AudioManager audio;

    private void Start()
    {
        Instance = this;
        SpawnBlock();
        audio = FindObjectOfType<AudioManager>();
        audio.Play("BackgroundMusic");
    }

    private void Update()
    {
        if (canSpawnBlocks)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isMousePressed = true;
                timePressed = Time.time;
            }

            if (isMousePressed && Time.time - timePressed >= spawnDelay)
            {
                SpawnBlock();
                isMousePressed = false;
            }
        }
    }

    private void SpawnBlock()
    {
        if (canSpawnBlocks)
        {
            GameObject newBlock = Instantiate(blockPrefab, spawnPoint);
            newBlock.transform.localPosition = Vector3.zero;
            // ScoreManager.Instance.AddScore(10);
        }
    }

    // Call this method to stop block spawning when the game is over
    public void StopBlockSpawning()
    {
        canSpawnBlocks = false;
    }
}
