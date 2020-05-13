using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightVR : GrabbableObjectVR
{
    private Light flashlight;
    private bool enable = false;

    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if (isBeingHeld)
        {
            if(controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                Interaction();
            }
            if(controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    void Interaction()
    {

        flashlight.enabled = !flashlight.enabled;
    }
}
