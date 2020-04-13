// Namespaces
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Transform location;
    private Vector3 otherLocation = new Vector3(500f, 50f, 500f);

    private Rigidbody liamRigidbody;
    public float moveSpeed;
    public float turnSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        liamRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region translational movement

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
            liamRigidbody.AddForce(Vector3.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }


        #endregion

        #region rotation using keyboard

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.Self);
        }

        #endregion

        #region rotation using mouse

        //transform.Rotate(Vector3.up );

        #endregion
    }

    void Peter()
    {
        transform.position = otherLocation;
    }
}
