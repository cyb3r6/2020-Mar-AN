using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleport : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The transform we want to teleport")]
    private Transform vrRig;

    private VRInput controller;
    private LineRenderer teleportVisual;
    private Vector3 hitPosition;
    private bool shouldTeleport;

    
    void Start()
    {
        teleportVisual = GetComponent<LineRenderer>();
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if (controller)
        {
            if (controller.isThumbstickPressed)
            {
                RaycastHit hit;
                if(Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, 10f))
                {
                    // Do the visuals!
                    hitPosition = hit.point;
                    teleportVisual.SetPosition(0, transform.position);
                    teleportVisual.SetPosition(1, hitPosition);
                    teleportVisual.enabled = true;
                    shouldTeleport = true;
                }
            }
            else if(controller.isThumbstickPressed == false)
            {
                // Do the teleporting!
                if (shouldTeleport == true)
                {
                    vrRig.transform.position = hitPosition;
                    shouldTeleport = false;
                    teleportVisual.enabled = false;
                }
            }
        }
    }
}
