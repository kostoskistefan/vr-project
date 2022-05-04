using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GazeInteraction : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private float durationInSeconds = 2f;

    [SerializeField] 
    private string interactionTag = "";
    
    private IEnumerator coroutine;
    public static GameObject currentObject;
    private float time = 0;

    public delegate void LookingAtInteractableObject(bool lookingAtInteractableObject);
    public static event LookingAtInteractableObject OnLookingAtInteractableObject;

    void Start()
    {
        coroutine = GazeCountdown();
    }

    void Update()
    {
        bool raycastIsValid = 
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit) && 
            hit.transform.tag == interactionTag;

        if(raycastIsValid)
        {
            currentObject = hit.transform.gameObject;
            StopCoroutine(coroutine);
            StartCoroutine(coroutine);
            OnLookingAtInteractableObject(true);
        }

        else
        {
            StopCoroutine(coroutine);
            OnLookingAtInteractableObject(false);
            time = 0;
        }
    }

    private IEnumerator GazeCountdown()
    {
        while(true)
        {
            if (time <= durationInSeconds)
                time += Time.deltaTime;

            else 
            {
                ExecuteEvents.Execute(currentObject.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                time = 0;
            }
                
            yield return null;
        }
    }
}
