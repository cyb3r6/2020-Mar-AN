using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSimHand : GrabbableObjectSimHand
{
    private Light flashlight;
    
    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
            }
        }
    }

    void Interaction()
    {
        
        flashlight.enabled = !flashlight.enabled;
    }
}
