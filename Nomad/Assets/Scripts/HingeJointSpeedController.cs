using UnityEngine;

public class AutomaticHingeRotation : MonoBehaviour
{
    public HingeJoint2D hingeJoint;
    public float rotationSpeed = 60.0f; // Adjust the speed as needed
    public float minAngle = -45.0f; // Minimum angle limit
    public float maxAngle = 45.0f; // Maximum angle limit

    private void Start()
    {
        // Ensure the HingeJoint2D is properly set in the Inspector
        if (hingeJoint == null)
        {
            Debug.LogError("HingeJoint2D not assigned!");
        }

        // Enable the motor to start automatic rotation
        hingeJoint.useMotor = true;

        // Set the motor's speed to the desired automatic rotation speed
        JointMotor2D motor = hingeJoint.motor;
        motor.motorSpeed = rotationSpeed;
        hingeJoint.motor = motor;
    }

    private void Update()
    {
        // Check if the joint has reached the angle limits
        if (hingeJoint.jointAngle <= minAngle || hingeJoint.jointAngle >= maxAngle)
        {
            // Reverse the motor's speed to change the rotation direction
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = -motor.motorSpeed;
            hingeJoint.motor = motor;
        }
    }
}
