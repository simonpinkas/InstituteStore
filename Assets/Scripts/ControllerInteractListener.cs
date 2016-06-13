using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.SceneManagement;
using RenderHeads.Media.AVProVideo;

public class ControllerInteractListener : MonoBehaviour {

    int grabbedObjectSceneIndex = 0;

    public bool testGrab = false;
    
    private Animator sceneAnimator;

    private SteamVR_TrackedObject thisTrackedObject;
    public SteamVR_TrackedObject otherTrackedObject;

    private uint thisControllerIndex;
    private uint otherControllerIndex;

    public MediaPlayer mp;

    private List<IntervalRendererActivator> activatorsRetail;
    private GameObject sceneCarVisor;
    private GameObject sceneCandle;
    private GameObject sceneBalanceBar;
    private GameObject sceneNailPolish;
    private GameObject sceneJetLagPills;
    private GameObject scene6UniverseBluRay;
    private GameObject scene7Avocado;
    

    // Use this for initialization
    void Start()

    {
        activatorsRetail = new List<IntervalRendererActivator>();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("ActivatorRetail"))
        {
            activatorsRetail.Add(go.GetComponent<IntervalRendererActivator>());
        }


        
        //sceneCarVisor = GameObject.FindGameObjectWithTag("1");
        //sceneCandle = GameObject.FindGameObjectWithTag("2");
        //sceneBalanceBar = GameObject.FindGameObjectWithTag("3");
        //sceneNailPolish = GameObject.FindGameObjectWithTag("4");
        //sceneJetLagPills = GameObject.FindGameObjectWithTag("5");
        scene6UniverseBluRay = GameObject.FindGameObjectWithTag("6");
        scene7Avocado = GameObject.FindGameObjectWithTag("7");

        thisTrackedObject = GetComponent<SteamVR_TrackedObject>();

        GetComponent<VRTK_InteractGrab>().ControllerGrabInteractableObject += DoInteractGrab;
        GetComponent<VRTK_InteractGrab>().ControllerUngrabInteractableObject += DoInteractUngrab;

        //GetComponent<SteamVR_InteractTouch>().ControllerTouchInteractableObject += DoInteractTouch;
        //GetComponent<SteamVR_InteractTouch>().ControllerUntouchInteractableObject += DoInteractUntouch;
    }
    
    void Update()
    {
        if (thisTrackedObject != null && otherTrackedObject != null)
        {
            thisControllerIndex = (uint)thisTrackedObject.index;
            otherControllerIndex = (uint)otherTrackedObject.index;
        }
    }
    

    void DebugLogger(uint index, string action, GameObject target, uint thisControllerIndex, uint otherControllerIndex)
    {
        Debug.Log("Controller(" + index + ") is "+ action + " an object named " + target.name + " This(" + thisControllerIndex + ") Other(" + otherControllerIndex +")");
    }
    

    void DoInteractGrab(object sender, ObjectInteractEventArgs e)
    {
        print("Grabbed Object: " + e.target.name);

/********************/        

        if (e.target.tag == "ProductCarVisor")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalDeactivateTargets();
                mp.Control.Seek(10000);
                mp.Control.Play();

            }
        }

/********************/

        if (e.target.tag == "ProductBalanceBar")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalDeactivateTargets();

            }
        }

/********************/

        if (e.target.tag == "ProductNailPolish")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalDeactivateTargets();

            }
        }

/********************/

        if (e.target.tag == "ProductJetLagPills")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)

            {
                ira.IntervalDeactivateTargets();

            }
        }

/********************/

        if (e.target.tag == "ProductUniverseBluRay")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalDeactivateTargets();

            }
        }

/********************/

        if (e.target.tag == "ProductAvocado")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalDeactivateTargets();

                mp.Control.Play();
            }
        }

    }

    void DoInteractUngrab(object sender, ObjectInteractEventArgs e)
    {
        print("Ungrabbed Object: " + e.target.tag);

        /********************/

        if (e.target.tag == "ProductCarVisor")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalActivateTargets();

            }
        }

        /********************/

        if (e.target.tag == "ProductBalanceBar")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalActivateTargets();

            }
        }

        /********************/

        if (e.target.tag == "ProductNailPolish")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalActivateTargets();

            }
        }

        /********************/

        if (e.target.tag == "ProductJetLagPills")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalActivateTargets();

            }
        }

        /********************/

        if (e.target.tag == "ProductUniverseBluRay")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalActivateTargets();

            }
        }

        /********************/

        if (e.target.tag == "ProductAvocado")
        {
            foreach (IntervalRendererActivator ira in activatorsRetail)
            {
                ira.IntervalActivateTargets();

            }
        }
    }

    
    
    
}