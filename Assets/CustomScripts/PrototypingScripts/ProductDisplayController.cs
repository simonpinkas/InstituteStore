using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ProductDisplayController : MonoBehaviour { 

    public int productNumber = 1;
    public bool DisplayStatus = false;

    public float activeDistance = 0.4f;
    
    List<GameObject> productDisplayObjects = new List<GameObject>();

    GameObject mainCamera;

    void Awake ()
    {
        //This finds each product associated with the current productNumber by tag
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Product" + productNumber.ToString() + "Display"))
        {
            productDisplayObjects.Add(go);
        }

        Debug.Log(productDisplayObjects.Capacity);
    }

    void Start ()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        foreach (GameObject go in productDisplayObjects)
        {
            go.SetActive(false);
        }
    }

    void Update ()
    {
        float playerDistance = Vector3.Distance(mainCamera.transform.position, transform.position);
        if (playerDistance <= activeDistance)
        {
            foreach(GameObject go in productDisplayObjects)
            {
                go.SetActive(true);
            }
        }
        if (playerDistance > activeDistance)
        {
            foreach(GameObject go in productDisplayObjects)
            {
                go.SetActive(false);
            }
        }
    }


   
    



    //BELOW IS CODE FOR CONTROLLING PRODUCT AREA ACTIVATION WITH A TRIGGER
    /*
     void OnTriggerEnter(Collider productAreaTrigger) 
     {
         DecoStatus = true;
         foreach (GameObject go in productDisplayObjects)
         {
             go.SetActive(true);
         }
     }
    
    void OnTriggerStay(Collider productAreaTrigger)
    {
        DecoStatus = true;
        //Debug.Log("productDecoStatus = true");

        foreach (GameObject go in productDisplayObjects)
        {
            go.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider productAreaTrigger)
    {
        DecoStatus = false;
        Debug.Log("productDecoStatus = true");

        foreach (GameObject go in productDisplayObjects)
        {
            go.SetActive(false);
        }
    }
    */
}




