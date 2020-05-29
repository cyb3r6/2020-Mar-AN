using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody cubeRigidbody;
    private AudioSource cubeExplosionSound;
    public WreckingResetButton resetButton;
    
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        cubeRigidbody = GetComponent<Rigidbody>();
        cubeExplosionSound = GetComponent<AudioSource>();

        resetButton.OnButtonPressed += ResetCubes;
    }

    public void ResetCubes()
    {
        // reset position
        transform.position = startPosition;
        transform.rotation = startRotation;

        // reset inerta
        cubeRigidbody.velocity = Vector3.zero;
        cubeRigidbody.angularVelocity = Vector3.zero;

        // show the cube
        GetComponent<Renderer>().enabled = true;

        // reset score
        GameManager.instance.numberofCubesDestroyed = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 5)
        {
            cubeExplosionSound.Play();

        }
    }

}
