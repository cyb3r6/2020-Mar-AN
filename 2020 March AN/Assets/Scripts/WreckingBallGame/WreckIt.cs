using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckIt : MonoBehaviour
{
    public Lever forwardBackwardLever, rightleftLever, upDownLever;
    public float speed, rotateSpeed;

    
    void Update()
    {
        // forward and backward
        if(Mathf.Abs(forwardBackwardLever.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackwardLever.NormalizedJointAngle();
        }

        // left and right
        if (Mathf.Abs(rightleftLever.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightleftLever.NormalizedJointAngle();
        }

        // up and down
        if (Mathf.Abs(upDownLever.NormalizedJointAngle()) > 0.05f)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * speed * upDownLever.NormalizedJointAngle();
        }

    }
}
