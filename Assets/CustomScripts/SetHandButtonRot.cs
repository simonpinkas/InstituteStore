using UnityEngine;
using System.Collections;

public class SetHandButtonRot : MonoBehaviour {

    public Transform controller;
    public Transform cameraHead;
    public float tilt = 2.0f;

    private GameObject lookAtAnchor;
    Vector3 newRot;
    
    void Start()
    {
        lookAtAnchor = new GameObject();
    }

    void Update()
    {
        lookAtAnchor.transform.position = controller.position;
        lookAtAnchor.transform.LookAt(cameraHead);

        transform.eulerAngles = new Vector3(0f, lookAtAnchor.transform.eulerAngles.y, 0f);
    }
}