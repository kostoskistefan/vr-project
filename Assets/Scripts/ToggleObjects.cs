using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objects;

    public void Toggle()
    {
        foreach (GameObject obj in objects)
            obj.SetActive(!obj.activeInHierarchy);
    }
}
