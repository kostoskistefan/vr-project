using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void OnEnable()
    {
        GazeInteraction.OnLookingAtInteractableObject += ScaleCrosshair;
    }

    void OnDisable()
    {
        GazeInteraction.OnLookingAtInteractableObject -= ScaleCrosshair;
    }

    void ScaleCrosshair(bool lookingAtInteractableObject)
    {
        RectTransform rect = this.GetComponent<RectTransform>();

        if (lookingAtInteractableObject)
            rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, new Vector2(3, 3), 2 * Time.deltaTime); 

        else
            rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, new Vector2(1, 1), 2 * Time.deltaTime); 
    }
}
