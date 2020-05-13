using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public GameObject collidingObject;  // what we're touching
    public GameObject heldObject;       // what we're holding
    public Transform snapPosition;

    public bool gripHeld;
    public bool triggerHeld;

    private VRInput controller;
    
    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller.gripValue > 0.8f && gripHeld == false)
        {
            gripHeld = true;

            // do the grabbing
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;
                Grab();
                
            }
        }
        else if(controller.gripValue < 0.8f && gripHeld == true)
        {
            gripHeld = false;

            // do the release
            if (heldObject)
            {
                Release();
            }
        }

        #region Using BroadcastMessage

        if(controller.triggerValue > 0.8f && !triggerHeld && heldObject)
        {
            heldObject.BroadcastMessage("Interaction");
            triggerHeld = true;
        }
        else if(controller.triggerValue < 0.8f && triggerHeld)
        {
            triggerHeld = false;
        }


        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    public void Grab()
    {
        Debug.Log("Grab is called");

        heldObject.transform.SetParent(this.snapPosition);
        
        heldObject.transform.rotation = snapPosition.rotation;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        #region Using GetComponent

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.controller = controller;
        }

        #endregion
    }

    public void Release()
    {
        Debug.Log("Release is called");

        #region Using GetComponent

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = null;
            grabbable.isBeingHeld = false;
            grabbable.controller = null;
        }

        #endregion

        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        //heldObject.transform.localPosition -= heldObject.GetComponent<GrabbableObjectSimHand>().grabOffset;
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity;
        heldObject.GetComponent<Rigidbody>().angularVelocity = controller.handAngularVelocity;
        heldObject = null;
    }

    // Using Fixed Joints
}
