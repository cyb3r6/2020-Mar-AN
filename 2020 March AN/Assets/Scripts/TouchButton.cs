using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    public Transform button, upTransform, downTransform;
    public AudioSource buttonClick;

    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = downTransform.position;
            buttonClick.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = upTransform.position;
        }
    }
}
