using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;
    
    public void TeleportPlayer()
    {
        player.transform.position = GazeInteraction.currentObject.transform.position;
        player.transform.rotation = GazeInteraction.currentObject.transform.rotation;
    }
}
