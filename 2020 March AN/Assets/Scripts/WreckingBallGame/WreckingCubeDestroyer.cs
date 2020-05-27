using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCubeDestroyer : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        // keep tally of how many cubes we've destroyed
        if(other.tag == "Paintable")
        {
            GameManager.instance.CountCubesDestroyed();
            other.GetComponent<Renderer>().enabled = false;
        }
    }
}
