using UnityEngine;
using System.Collections;

public class SetHandButtonPos : MonoBehaviour {

    public Transform controllerAttachPoint;

    void FixedUpdate()
    {   
        transform.position = controllerAttachPoint.position;
    }
}