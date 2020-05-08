using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPaintballVR : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Interaction()
    {
        GameObject tempPaintball = Instantiate(paintballPrefab, spawnPoint.position, spawnPoint.rotation);
        tempPaintball.GetComponent<Rigidbody>().AddForce(tempPaintball.transform.forward * shootingForce);
        Destroy(tempPaintball, 5f);
        shotCounterScript.shotsFired++;
    }
}
