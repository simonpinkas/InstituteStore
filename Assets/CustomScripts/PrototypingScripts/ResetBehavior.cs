using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResetBehavior : MonoBehaviour {




    public static void Reset()
    {
        foreach (StartData sd in FindObjectsOfType(typeof(StartData)))
        {
            Rigidbody rb = sd.gameObject.GetComponent<Rigidbody>();

            sd.gameObject.transform.position = sd.startPosition;
            sd.gameObject.transform.eulerAngles = sd.startRotation;

            if (rb != null)
            {
                rb.velocity = sd.startVelocity;
                rb.angularVelocity = sd.startAngularVelocity;
            }
        }
        
        
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product"))
        {
            go.SetActive(true);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("RetailFloor"))
        {
            go.SetActive(true);
        }



        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product1Display"))
        {
            go.SetActive(false);
        }

        /*
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product2Display"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product3Display"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product4Display"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product5Display"))
        {
            go.SetActive(false);
        }




        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product1Scene"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product2Scene"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product3Scene"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product4Scene"))
        {
            go.SetActive(false);
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Product5Scene"))
        {
            go.SetActive(false);
        }
        */
    }
}

