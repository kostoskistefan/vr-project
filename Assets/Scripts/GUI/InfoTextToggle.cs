using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTextToggle : MonoBehaviour
{
    [SerializeField]
    private GameObject textObject;

    void OnEnable()
    {
        Teleporter.OnLookingAtTeleporter += DisplayTeleportingText;
    }

    void OnDisable()
    {
        Teleporter.OnLookingAtTeleporter -= DisplayTeleportingText;
    }

    void DisplayTeleportingText(bool lookingAtTeleporter)
    {
        textObject.SetActive(lookingAtTeleporter);
    }
}
