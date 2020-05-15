using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightVR : GrabbableObjectVR
{
    private Light flashlight;
    private bool enable = false;
    public List<Chase> chaseScripts;
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

        RaycastHit hit;
        if (Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit))
        {
            if (hit.transform.tag == "Chaser")
            {
                foreach(Chase chasee in chaseScripts)
                {
                    chasee.startStop = !flashlight.enabled;
                }                
            }
            else
            {
                foreach (Chase chasee in chaseScripts)
                {
                    chasee.startStop = true;
                }
            }
        }
    }

    void Interaction()
    {

        flashlight.enabled = !flashlight.enabled;
    }
}
