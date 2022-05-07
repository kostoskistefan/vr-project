using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactor : MonoBehaviour
{
    public static GameObject currentObject = null;

    private float time = 0;

    public delegate void LookingAtInteractableObject(bool lookingAtInteractableObject);
    public static event LookingAtInteractableObject OnLookingAtInteractableObject;

    private bool countdownStarted = false;

    void Update()
    {
        bool raycastIsValid = 
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit) && 
            hit.transform.tag == "Interactable";

        OnLookingAtInteractableObject(raycastIsValid);

        if (raycastIsValid)
        {
            currentObject = hit.transform.gameObject;
            
            GazeCountdown();
        } 

        else ResetCountdown();
    }

    private void ResetCountdown()
    {
        time = 0;
        countdownStarted = false;
        currentObject = null;
    }

    private void GazeCountdown()
    {
        if (time <= 2f)
            time += Time.deltaTime;

        else 
        {
            if(!countdownStarted)
            {
                countdownStarted = true;

                ExecuteEvents.Execute(currentObject.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
            }

            time = 0;
        } 
    }
}
