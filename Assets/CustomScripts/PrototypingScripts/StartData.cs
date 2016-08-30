using UnityEngine;
using System.Collections;

public class StartData : MonoBehaviour {

    [HideInInspector]
    public Vector3 startPosition;
    [HideInInspector]
    public Vector3 startRotation;
    [HideInInspector]
    public Vector3 startVelocity;
    [HideInInspector]
    public Vector3 startAngularVelocity;

 
    

        // Use this for initialization
        void Awake()
        {
            startPosition = gameObject.transform.position;
            Debug.Log(gameObject.name + " Start Pos: " + startPosition.ToString());
            startRotation = transform.eulerAngles;
            Debug.Log(gameObject.name + " Start Rot: " + startRotation.ToString());

            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                startVelocity = rb.velocity;
                startAngularVelocity = rb.angularVelocity;
            }

         
        }
    }