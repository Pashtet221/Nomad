using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance {get; private set;}

    public float height = 5f;
    public float speed = 0.5f;
    private bool canMoveCamera = true; // Flag to control camera movement

    private void Start()
    {
        Instance = this;
        // Initialize DOTween
        DOTween.Init();
    }

    private void Update()
    {
        if (canMoveCamera && Input.GetMouseButtonDown(0))
        {
            // Move the camera upward smoothly using an easing function
            float targetY = transform.position.y + height;
            float duration = speed;
            Ease easingFunction = Ease.OutQuad; // Change this to your desired easing function

            transform.DOMoveY(targetY, duration).SetEase(easingFunction);
        }
    }

    // Call this method to stop camera movement
    public void StopCameraMovement()
    {
        canMoveCamera = false;
    }
}
