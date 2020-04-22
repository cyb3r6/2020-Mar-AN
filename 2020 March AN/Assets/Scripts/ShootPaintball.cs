using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintball : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
            tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
            //Destroy(tempPaintball, 5f);
        }
    }
}
