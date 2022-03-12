using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] private float thrust = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Jump
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Space");
            rgbd.AddForce(transform.localEulerAngles.normalized * Physics.gravity.magnitude * thrust);
        }

        //

    }
}
