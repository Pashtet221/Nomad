using UnityEngine;
using System.Collections;
using EasyUI.Popup;

public class TowerBlockController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Collider2D collider2D;
    private bool isGameOver = false;
    private bool canFreezeRotation = true;
    private float rotationFreezeDelay = 3f;
    private bool canInteract = true; // Add a flag to control interactions
    private float lastCollisionTime = 0f; // Store the time of the last collision
    private bool touchingChip = false; // Flag to track if the block is touching "Chip"

    public GameObject popupPrefab;

    private AudioManager audio;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.isKinematic = true;
        collider2D = GetComponent<Collider2D>();
        audio = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (!isGameOver && canInteract && Input.GetMouseButtonDown(0))
        {
            StartRotationFreeze();
            touchingChip = false; // Reset the touchingChip flag
        }
    }

    private void StartRotationFreeze()
    {
        rigidBody2D.isKinematic = false;
        StartCoroutine(FreezeRotationAfterDelay(rotationFreezeDelay));
        canFreezeRotation = false;
        canInteract = false; // Disable further interaction
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chip"))
        {
            ScoreManager.Instance.AddScore(5, 1);
            audio.Play("BoxDrop");
            touchingChip = true; // Set touchingChip to true when touching "Chip"
        }
        else if (collision.gameObject.CompareTag("Chip") && canFreezeRotation)
        {
            // Make the block immovable after falling
            // Implement logic here if needed
        }

        // Store the time of the collision
        lastCollisionTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TriggerZone"))
        {
            ReduceHealth();
        }
    }

    private void ReduceHealth()
    {
        Health.Instance.health--;

        if (Health.Instance.health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("GameOver!");
        audio.Play("Lose");
        isGameOver = true;
        canInteract = false; // Disable interaction on game over
        TowerBlockSpawner.Instance.StopBlockSpawning();
        CameraMovement.Instance.StopCameraMovement();

        // Popup.Show("Результат", "Для зачисления результата, пожалуйста введите имя и сделайте фото профиля", "Хорошо");

        GameObject popupInstance = Instantiate(popupPrefab);
    }

    private IEnumerator FreezeRotationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
