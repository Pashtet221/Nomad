using UnityEngine;

public class RaiseTriggerZone : MonoBehaviour
{
    public float raiseAmount = 1.0f; // The amount to raise the Trigger Zone with each click

    private Vector3 initialPosition; // Store the initial position of the Trigger Zone

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Raise();
        }
    }

    private void Raise()
    {
        // Calculate the new position by adding the raiseAmount to the Y coordinate
        Vector3 newPosition = transform.position + Vector3.up * raiseAmount;

        // Move the Trigger Zone to the new position
        transform.position = newPosition;
    }

    // Reset the Trigger Zone to its initial position
    public void ResetPosition()
    {
        transform.position = initialPosition;
    }
}
