using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerZone : MonoBehaviour
{
    public Animator bridgeAnim;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("the object that entered the bridge triggerzone is: " + other.gameObject.name);
        if(other.gameObject.tag == "Player")
        {
            bridgeAnim.SetTrigger("RaiseBridge");
        }        
    }
}
