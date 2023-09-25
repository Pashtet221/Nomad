using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabMovement : MonoBehaviour
{
    public float speed = 5f;
    public PrefabType prefabType; // Enum to specify the type of prefab

    private void FixedUpdate()
    {
        float moveX = 0f;
        float moveY = 0f;

        switch (prefabType)
        {
            case PrefabType.Diagonal:
                moveX = speed * Time.deltaTime;
                moveY = speed * Time.deltaTime;
                break;
            case PrefabType.Vertical:
                moveY = speed * Time.deltaTime;
                break;
            case PrefabType.Horizontal:
                moveX = speed * Time.deltaTime;
                break;
        }

        transform.Translate(new Vector3(moveX, moveY, 0f));
    }
}


public enum PrefabType
{
    Diagonal,
    Vertical,
    Horizontal
}
