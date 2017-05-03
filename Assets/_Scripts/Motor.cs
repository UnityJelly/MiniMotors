using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
    public Transform centerOfMass;
    public Wheel[] wheel;
    public float enginePower = 50f;
    public float turnPower = 20f;


    Rigidbody rbody;

    void Awake()
    {
        rbody = GetComponent<Rigidbody>();    
    }

    void Start()
    {
        rbody.centerOfMass = centerOfMass.localPosition;
    }

    void FixedUpdate()
    {
        float torque = Input.GetAxis("Vertical") * enginePower;
        float turnSpeed = Input.GetAxis("Horizontal") * turnPower;

        if (torque != 0)
        {
            //Front wheel drive
            //wheel[0].Move(torque);
            //wheel[1].Move(torque);

            //Rear Wheel drive
            //     wheel[2].Move(torque);
            //     wheel[3].Move(torque);

            // Four wheel drive
            wheel[0].Move(torque);
            wheel[1].Move(torque);
            wheel[2].Move(torque);
            wheel[3].Move(torque);
        }       
        // Front wheel steering
        wheel[0].Turn(turnSpeed);
        wheel[1].Turn(turnSpeed);

        // Rear wheel steering
        // wheel[2].Turn(turnSpeed);
        // wheel[3].Turn(turnSpeed);
    }
}
