using UnityEngine;
using System.Collections;

public class DisableRenderersOnStart : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        foreach (Renderer component in GetComponentsInChildren<Renderer>())
        {
            component.enabled = false;
        }

       foreach (Light component in GetComponentsInChildren<Light>())
        {
            component.enabled = false;
        }

       foreach (Terrain component in GetComponentsInChildren<Terrain>())
        {
            component.enabled = false;
        }

    }
    // Update is called once per frame
    void Update()

    {
    }
}