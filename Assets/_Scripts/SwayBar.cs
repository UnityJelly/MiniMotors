using System.Collections;
using UnityEngine;

public class SwayBar : MonoBehaviour {
    public WheelCollider WheelL;
    public WheelCollider WheelR;
    public float AntiRoll = 5000.0f;

    public Rigidbody rbody;

	// Update is called once per frame
	void FixedUpdate () {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;

        bool groundedL = WheelL.GetGroundHit(out hit);
        if (groundedL)
            travelL = (-WheelL.transform.InverseTransformPoint(hit.point).y - WheelL.radius) / WheelL.suspensionDistance;

        bool groundedR = WheelR.GetGroundHit(out hit);
        if (groundedR)
            travelL = (-WheelR.transform.InverseTransformPoint(hit.point).y - WheelR.radius) / WheelR.suspensionDistance;

        float antiRollForce = (travelL - travelR) * AntiRoll;

        if (groundedL)
            rbody.AddForceAtPosition(WheelL.transform.up * -antiRollForce, WheelL.transform.position);
        if (groundedR)
            rbody.AddForceAtPosition(WheelR.transform.up * -antiRollForce, WheelR.transform.position);
    }
}
