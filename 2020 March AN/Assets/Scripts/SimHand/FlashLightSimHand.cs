using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSimHand : GrabbableObjectSimHand
{
    private Light flashlight;
    public List<Chase> chaseScripts;

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

        RaycastHit hit;
        if(Physics.Raycast(flashlight.transform.position, flashlight.transform.forward, out hit))
        {
            if (hit.transform.tag == "Chaser")
            {
                foreach (Chase chasee in chaseScripts)
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
