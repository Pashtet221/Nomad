using UnityEngine;

public class ObjectMoving : MonoBehaviour
{
    public float speed = 1f; // The speed at which the object moves

    private Vector2 moveDirection;

    private void Start()
    {
        // Randomly choose the initial movement direction (left or right)
        moveDirection = Random.Range(0, 2) == 0 ? Vector2.left : Vector2.right;
    }

    private void Update()
    {
        // Move the object based on the chosen direction
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
