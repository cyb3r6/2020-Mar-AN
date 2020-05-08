using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectSimHand : MonoBehaviour
{
    public GameObject hand;
    public SimHandGrab simHandController;
    public bool isBeingHeld;

    public Vector3 grabOffset = Vector3.zero;
        
}
