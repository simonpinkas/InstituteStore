using UnityEngine;
using System.Collections;

public class StartRotationLock : MonoBehaviour
{
    public Transform controller;


    void LateUpdate()
    {

        //this.transform.parent = controller.gameObject.transform;
        transform.eulerAngles = new Vector3 (controller.transform.eulerAngles.x, 0.0f, controller.transform.eulerAngles.z);

    }
}



