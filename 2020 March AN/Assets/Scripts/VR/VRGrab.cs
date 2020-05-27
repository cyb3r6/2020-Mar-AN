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

    public float throwForce;

    private Vector3 handVelocity;
    private Vector3 previousPosition;
    private Vector3 handAngularVelocity;
    private Vector3 previousAngularRotation;

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
                //Grab();
                AdvGrab();
            }
        }
        else if(controller.gripValue < 0.8f && gripHeld == true)
        {
            gripHeld = false;

            // do the release
            if (heldObject)
            {
                //Release();
                AdvRelease();
            }
        }

        #region Using BroadcastMessage

        if(controller.triggerValue > 0.8f && !triggerHeld && heldObject)
        {
            //heldObject.BroadcastMessage("Interaction");
            triggerHeld = true;
        }
        else if(controller.triggerValue < 0.8f && triggerHeld)
        {
            triggerHeld = false;
        }

        #endregion

        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        handAngularVelocity = (this.transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = this.transform.eulerAngles;
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
    private void AdvGrab()
    {
        FixedJoint fixJoint = gameObject.AddComponent<FixedJoint>();
        fixJoint.breakForce = 2000;
        fixJoint.breakTorque = 2000;
        fixJoint.connectedBody = heldObject.GetComponent<Rigidbody>();

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

    private void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            #region Using GetComponent

            var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.controller = null;
            }

            #endregion

            Destroy(GetComponent<FixedJoint>());

            heldObject.GetComponent<Rigidbody>().velocity = handVelocity * throwForce;
            heldObject.GetComponent<Rigidbody>().angularVelocity = handAngularVelocity * throwForce;
        }
        heldObject = null;
    }
}
