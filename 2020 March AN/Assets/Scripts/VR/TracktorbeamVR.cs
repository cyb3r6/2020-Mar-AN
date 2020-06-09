using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TracktorbeamVR : GrabbableObjectVR
{
    public Transform startingPoint;
    public float tractorBeamSpeed;
    private LineRenderer tractorBeam;
    private RaycastHit hit;
    private Transform hitTransform;
    private Rigidbody hitRigidbody;

    
    void Start()
    {
        tractorBeam = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (controller.triggerValue > 0.5f)
            {
                Interaction();
            }
            else
            {
                Drop();
            }
        }
    }

    public override void Interaction()
    {
        if(Physics.Raycast(startingPoint.position, transform.forward, out hit))
        {
            hitTransform = hit.transform;
            tractorBeam.enabled = true;
            tractorBeam.SetPosition(0, startingPoint.position);
            tractorBeam.SetPosition(1, hit.point);

            hitRigidbody = hitTransform.GetComponent<Rigidbody>();

            if(hitRigidbody && !hitRigidbody.isKinematic)
            {
                hitTransform.position = Vector3.Lerp(hitTransform.position, startingPoint.position, Time.deltaTime);
                //hitTransform.position = Vector3.MoveTowards(hitTransform.position, startingPoint.position, Time.deltaTime * tractorBeamSpeed);
                hitRigidbody.useGravity = false;
            }
            else
            {
                hitTransform = null;
            }
        }
        else
        {
            Drop();
        }
    }
   
    void Drop()
    {
        tractorBeam.enabled = false;
        if (hitTransform)
        {
            hitRigidbody.useGravity = true;
            hitTransform = null;
            hitRigidbody = null;
        }
    }
}
