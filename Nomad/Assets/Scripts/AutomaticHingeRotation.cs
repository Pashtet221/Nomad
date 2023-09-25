using UnityEngine;

public class AdjustableHingeJoint : MonoBehaviour
{
    public HingeJoint2D hingeJoint;
    public float minSpeed = -100f;
    public float maxSpeed = 100f;

    private void FixedUpdate()
    {
        // Check for user input or other conditions to adjust the speed
        float inputSpeed = Input.GetAxis("Horizontal"); // Example: Use horizontal input axis

        // Map the input to a speed within the defined range
        float newSpeed = Mathf.Lerp(minSpeed, maxSpeed, (inputSpeed + 1f) / 2f);

        // Apply the new speed to the HingeJoint2D motor
        JointMotor2D motor = hingeJoint.motor;
        motor.motorSpeed = newSpeed;
        hingeJoint.motor = motor;
    }
}
