using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public HingeJoint leverJoint;

    public float NormalizedJointAngle()
    {
        float normalizedAngle = leverJoint.angle / leverJoint.limits.max;
        return normalizedAngle;
    }
}
