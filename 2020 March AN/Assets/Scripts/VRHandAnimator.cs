using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAnimator : MonoBehaviour
{
    private VRInput controller;
    private Animator vrHandAnimator;

    void Awake()
    {
        controller = GetComponent<VRInput>();
        vrHandAnimator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if (controller)
        {
            vrHandAnimator.Play("Fist Closing", 0, controller.gripValue);
        }
    }
}
