﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public HingeJoint leverJoint;
    public Vector3 centerOfMass;
    private Rigidbody leverRigidbody;

    private void Start()
    {
        leverRigidbody = GetComponent<Rigidbody>();
        leverRigidbody.centerOfMass = centerOfMass;
    }

    // number between -1 and 1
    public float NormalizedJointAngle()
    {
        float normalizedAngle = leverJoint.angle / leverJoint.limits.max;
        return normalizedAngle;
    }
}
