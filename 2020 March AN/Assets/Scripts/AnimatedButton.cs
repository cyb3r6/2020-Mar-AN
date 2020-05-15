using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedButton : MonoBehaviour
{
    //public AudioSource buttonClick;
    public Animator buttonAnim;
    public UnityEvent buttonPressedEvent;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");
            buttonPressedEvent?.Invoke();
        }
    }
    
}
