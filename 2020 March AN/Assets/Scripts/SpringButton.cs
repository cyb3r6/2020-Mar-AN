using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpringButton : MonoBehaviour
{
    public UnityEvent buttonPressedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SpringButton")
        {
            buttonPressedEvent?.Invoke();
        }
    }
}
