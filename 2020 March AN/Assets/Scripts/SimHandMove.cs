// Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Transform location;
    public Vector3 otherLocation;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = otherLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
