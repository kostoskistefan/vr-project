using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    
    private IEnumerator coroutine;
    private GameObject currentTeleporter;
    private float time = 0;

    public delegate void LookingAtTeleporter(bool lookingAtTeleporter);
    public static event LookingAtTeleporter OnLookingAtTeleporter;

    void Start()
    {
        coroutine = TeleportationCoundown();
    }

    void Update()
    {
        bool raycastIsValid = 
            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit) && 
            hit.transform.tag == "Teleportation Point";

        if(raycastIsValid)
        {
            currentTeleporter = hit.transform.gameObject;
            StopCoroutine(coroutine);
            StartCoroutine(coroutine);
            OnLookingAtTeleporter(true);
        }

        else
        {
            StopCoroutine(coroutine);
            OnLookingAtTeleporter(false);
            time = 0;
        }
    }

    private IEnumerator TeleportationCoundown()
    {
        int duration = 3;

        while(true)
        {
            if (time <= duration)
                time += Time.deltaTime;

            else 
            {
                player.transform.position = currentTeleporter.transform.position;
                player.transform.rotation = currentTeleporter.transform.rotation;
                time = 0;
            }
                
            yield return null;
        }

    }
}
