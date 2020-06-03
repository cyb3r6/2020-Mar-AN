using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintballVR : GrabbableObjectVR
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;

    private bool enable = false;
    
    void Update()
    {
        if(isBeingHeld == true)
        {
            if(controller.triggerValue > 0.5f && !enable)
            {
                enable = true;
                Interaction();
            }
            if(controller.triggerValue < 0.5f && enable)
            {
                enable = false;
            }
        }
    }   

    public override void Interaction()
    {
        GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
        tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
        Destroy(tempPaintball, 5f);
        shotCounterScript.shotsFired++;
    }
}
