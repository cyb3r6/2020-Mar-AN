using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintball : GrabbableObjectSimHand
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;
    //public SimHandGrab simHandController;
    //private GrabbableObjectSimHand grabbableObjectSimHand;

    //private void Awake()
    //{
    //    grabbableObjectSimHand = GetComponent<GrabbableObjectSimHand>();
    //}

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
        //    tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
        //    Destroy(tempPaintball, 5f);
        //    shotCounterScript.shotsFired++;
        //}

        if(isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interaction();
            }
        }
    }

    void Interaction()
    {
        GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
        tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
        Destroy(tempPaintball, 5f);
        shotCounterScript.shotsFired++;
    }
}
