using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public enum TargetListener
    {
        OffPopup,
        OnPopup
    }

    [SerializeField] private TargetListener targetListener;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject cameraPopup;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();

        button.onClick.RemoveAllListeners();

        switch (targetListener)
        {
            case TargetListener.OffPopup:
                button.onClick.AddListener(() =>
                {
                    popup.SetActive(false);
                    cameraPopup.SetActive(true);
                });
                break;

            case TargetListener.OnPopup:
                button.onClick.AddListener(() => 
                {
                    popup.SetActive(true);
                    cameraPopup.SetActive(false);
                    WebCam.instance.StopWebCam();
                });
                break;
        }
    }
}
