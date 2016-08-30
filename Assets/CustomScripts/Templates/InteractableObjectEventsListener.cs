
namespace VRTK { 

using UnityEngine;
using System.Collections;

public class InteractableObjectEventsListener: MonoBehaviour {

	// Use this for initialization
	void Start () {
     
        //Setup controller event listeners
        GetComponent<VRTK_InteractableObject>().InteractableObjectTouched += DoInteractableObjectTouched;
        GetComponent<VRTK_InteractableObject>().InteractableObjectUntouched += DoInteractableObjectUntouched;

        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += DoInteractableObjectGrabbed;
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += DoInteractableObjectUngrabbed;

        GetComponent<VRTK_InteractableObject>().InteractableObjectUsed += DoInteractableObjectUsed;
        GetComponent<VRTK_InteractableObject>().InteractableObjectUnused += DoInteractableObjectUnused;
    }

    

    void DoInteractableObjectTouched(object sender, InteractableObjectEventArgs e)
    {
        print(e.interactingObject + "TOUCHED");
    }

    void DoInteractableObjectUntouched(object sender, InteractableObjectEventArgs e)
    {
        print(e.interactingObject + "UNTOUCHED");
    }

    void DoInteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        print(e.interactingObject + "GRABBED");
    }

    void DoInteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        print(e.interactingObject + "UNGRABBED");
    }

    void DoInteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        print(e.interactingObject + "USED");
    }

    void DoInteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        print(e.interactingObject + "UNUSED");
    }
}
}

