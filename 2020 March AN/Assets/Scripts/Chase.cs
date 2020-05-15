using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform target;
    public int moveSpeed = 1;
    public float stoppingDistance = 2f;
    public bool startStop = true;

        
    void Update()
    {
        transform.LookAt(target);
        if (!startStop)
        {
            transform.position = this.transform.position;
        }
        else
        {
            StartMove();
        }        
    }

    private void StartMove()
    {
        if(Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }        
    }

}
