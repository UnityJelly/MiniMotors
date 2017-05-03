using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour {
    const string TIRE_NAME = "Tire";
    [SerializeField] Transform tire; 
    WheelCollider wheelCollider;

    void Awake()
    {
        wheelCollider = GetComponent<WheelCollider>();
        tire = transform.FindChild(TIRE_NAME);
    }

    public void Move(float value)
    {
        wheelCollider.motorTorque = value;
    }

    public void Turn(float value)
    {
        wheelCollider.steerAngle = value;
        tire.localEulerAngles = new Vector3 (0f, wheelCollider.steerAngle, 90f);
    }
}
