using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    
    public void TeleportPlayer()
    {
        player.transform.position = Interactor.currentObject.transform.position;
        player.transform.rotation = Interactor.currentObject.transform.rotation;
    }
}
