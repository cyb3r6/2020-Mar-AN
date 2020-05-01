using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;  // what we're touching
    public GameObject heldObject;       // what we're holding
    public Transform snapPosition;

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Update()
    {
        // check for input
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // do the grabbing
            if(collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;
                Grab();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            // do the release
            if (heldObject)
            {
                Release();
            }

        }
    }

    public void Grab()
    {
        heldObject.transform.SetParent(this.snapPosition);
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.rotation = snapPosition.rotation;
    }

    public void Release()
    {
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
