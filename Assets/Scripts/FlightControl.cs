using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rgbd;
    [SerializeField] float thrust;
    [SerializeField] float pitchDeg;
    [SerializeField] float rollDeg;
    [SerializeField] float yawDeg;

    private bool turtle = false;
    private int thrusting = 0;
    private int pitching = 0;
    private int rolling = 0;
    private int yawing = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Retry
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(-1.6f, 2f, 10.51f);
            transform.eulerAngles = new Vector3(0, 146.78f, 0);
        }

        // Thrust Up
        if (Input.GetKeyDown(KeyCode.W))
        {
            thrusting = 1;
        }
        if (Input.GetKeyUp(KeyCode.W)) thrusting = 0;

        // Thrust Down
        if (Input.GetKeyDown(KeyCode.S)) thrusting = -1;
        if (Input.GetKeyUp(KeyCode.S)) thrusting = 0;

        // Global Up (Turtle)
        if (Input.GetKeyDown(KeyCode.E)) turtle = true;
        if (Input.GetKeyUp(KeyCode.E)) turtle = false;

        // Pitch Forward
        if (Input.GetKeyDown(KeyCode.I)) pitching = 1;
        if (Input.GetKeyUp(KeyCode.I)) pitching = 0;

        // Pitch Backward
        if (Input.GetKeyDown(KeyCode.K)) pitching = -1;
        if (Input.GetKeyUp(KeyCode.K)) pitching = 0;

        // Roll Left
        if (Input.GetKeyDown(KeyCode.J)) rolling = 1;
        if (Input.GetKeyUp(KeyCode.J)) rolling = 0;

        // Roll Right
        if (Input.GetKeyDown(KeyCode.L)) rolling = -1;
        if (Input.GetKeyUp(KeyCode.L)) rolling = 0;

        // Yaw Left
        if (Input.GetKeyDown(KeyCode.A)) yawing = -1;
        if (Input.GetKeyUp(KeyCode.A)) yawing = 0;

        // Yaw Right
        if (Input.GetKeyDown(KeyCode.D)) yawing = 1;
        if (Input.GetKeyUp(KeyCode.D)) yawing = 0;
    }

    private void FixedUpdate()
    {
        // Turtle
        if (turtle) rgbd.AddForce(Vector3.up * Physics.gravity.magnitude * thrust * Time.fixedDeltaTime);

        // Roll, Pitch, Yaw
        transform.Rotate(pitching * pitchDeg, yawing * yawDeg, rolling * rollDeg, Space.Self);

        // Thrust
        rgbd.AddForce(transform.up * Physics.gravity.magnitude * thrust * thrusting * Time.fixedDeltaTime);
    }
}
