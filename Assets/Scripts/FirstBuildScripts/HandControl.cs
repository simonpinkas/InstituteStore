using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class HandControl : MonoBehaviour {

    public Animator handAnimator;

    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device { get { return SteamVR_Controller.Input((int)trackedObj.index); } }


	void Awake () {           //Changed to Awake so this is running when the game first starts, if it were Start, it might give a "no pointer error" -from tutorial
        trackedObj = GetComponent<SteamVR_TrackedObject>();		
    }

	void FixedUpdate ()
    {                                                           
        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))     //SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

        {
            handAnimator.SetBool("isGrabbing", true);
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            handAnimator.SetBool("isGrabbing", false);
        }
    }

    void Update()
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

            //ResetBehavior[] rbs = FindObjectsOfType<ResetBehavior>();

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            
            ResetBehavior.Reset();

            /*
            foreach (ResetBehavior rb in rbs)
            {
                   rb.Reset();
            }
            */
        }
    }
    
    Collider objectsCollider;

    
    void OnTriggerStay(Collider objectsCollider) //How is this being connected to the collider?
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            objectsCollider.attachedRigidbody.isKinematic = true ;
            objectsCollider.gameObject.transform.SetParent(this.gameObject.transform);

			if (objectsCollider.gameObject.GetComponent<WorldAnchor>() != null) {
				objectsCollider.gameObject.GetComponent<WorldAnchor>().Switch();
			}
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You have released Touch while colliding with" + objectsCollider.name);
            tossObject(objectsCollider.attachedRigidbody);
            objectsCollider.gameObject.transform.SetParent(null);
            
        }
    }

    void tossObject(Rigidbody objectsRigidBody)
    {
        SteamVR_Controller.Device device = SteamVR_Controller.Input((int)trackedObj.index);
        Transform origin = trackedObj.origin;

        if (origin != null)
        {
            objectsRigidBody.velocity = origin.TransformVector(device.velocity);
            objectsRigidBody.angularVelocity = origin.TransformVector(device.angularVelocity);
        }

        objectsRigidBody.isKinematic = false;

        objectsRigidBody.velocity = device.velocity;
        objectsRigidBody.angularVelocity = device.angularVelocity;
    }
}
