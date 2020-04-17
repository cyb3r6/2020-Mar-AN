using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintball : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
