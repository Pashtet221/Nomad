using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class WebCam : MonoBehaviour
{
    public static WebCam instance {get; private set;}
    
    int currentCamIndex = 0;
    WebCamTexture tex;
    public RawImage display;
    public Text startStopText;

    // Define a variable to store the captured photo
    private Texture2D capturedPhoto;

    private AudioManager audio;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        capturedPhoto = new Texture2D(1, 1); // Initialize the texture for capturing photos
        audio = FindObjectOfType<AudioManager>();

        if (gameObject.activeSelf)
        {
            StartStopCam_Clicked();
        }
    }

    public void SwapCam_Clicked()
    {
        if (WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;

            if (tex != null)
            {
                StopWebCam();
                StartStopCam_Clicked();
            }
        }
    }

    public void StartStopCam_Clicked()
    {
        if (tex != null) // Stop the camera
        {
            StopWebCam();
            startStopText.text = "Start Camera";
        }
        else // Start the camera
        {
            // Check if the current platform is iOS (iPhone)
            if (Application.platform == RuntimePlatform.IPhonePlayer)
            {
                // Use the front camera on iPhones
                tex = new WebCamTexture(WebCamTexture.devices[currentCamIndex].name, Screen.width, Screen.height);
            }
            else
            {
                // Use the default camera on other platforms
                tex = new WebCamTexture(WebCamTexture.devices[currentCamIndex].name);
            }

            display.texture = tex;

            tex.Play();
            startStopText.text = "Stop Camera";
        }
    }

    // Capture a photo from the webcam texture
    public void TakePhoto()
    {
        audio.Play("CameraShot");
        if (tex != null)
        {
            // Capture a single frame from the webcam texture
            tex.Pause(); // Pause the webcam to capture a still frame
            capturedPhoto = new Texture2D(tex.width, tex.height);
            capturedPhoto.SetPixels(tex.GetPixels());
            capturedPhoto.Apply();
            tex.Play(); // Resume the webcam

            // Define the file path for saving the image to the persistent data path
            string filePath = Application.persistentDataPath + "/CapturedPhoto.png";

            // Save the captured photo as an image file (e.g., PNG) to the persistent data path
            byte[] bytes = capturedPhoto.EncodeToPNG();
            File.WriteAllBytes(filePath, bytes);

            // Log the saved file path
            Debug.Log("Saved image to: " + filePath);

            Invoke("PopupOff", 2f);
        }
    }

    public void PopupOff()
    {
        // CameraPopup.instance.PopupOff();
    }

    public void StopWebCam()
    {
        display.texture = null;
        tex.Stop();
        tex = null;
    }
}
