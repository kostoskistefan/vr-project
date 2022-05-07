using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void OnEnable()
    {
        Interactor.OnLookingAtInteractableObject += ScaleCrosshair;
    }

    void OnDisable()
    {
        Interactor.OnLookingAtInteractableObject -= ScaleCrosshair;
    }

    void ScaleCrosshair(bool lookingAtInteractableObject)
    {
        RectTransform rect = this.GetComponent<RectTransform>();

        if (lookingAtInteractableObject)
            rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, new Vector2(2, 2), 2 * Time.deltaTime); 

        else
            rect.sizeDelta = Vector2.Lerp(rect.sizeDelta, new Vector2(1, 1), 2 * Time.deltaTime); 
    }
}
