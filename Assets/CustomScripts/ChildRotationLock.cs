using UnityEngine;
using System.Collections;

public class ChildRotationLock : MonoBehaviour
{


    Quaternion rotation;
    void Awake()
    {
        rotation = transform.rotation;
    }
    void LateUpdate()
    {
        transform.rotation = rotation;
    }
}



