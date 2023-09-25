using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPopup : MonoBehaviour
{
    public static CameraPopup instance {get; private set;}

    public GameObject popup;


    private void Awake()
    {
        instance = this;
        PopupOff();
    }

    public void PopupOn()
    {
        popup.gameObject.SetActive(true);
    }

    public void PopupOff()
    {
        popup.gameObject.SetActive(false);
    }
}
