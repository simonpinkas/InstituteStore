using UnityEngine;
using System.Collections;

public class SetHandButtonPos : MonoBehaviour {

    public Transform controller;

    void Update()
    {   
        transform.position = controller.position;
    }
}