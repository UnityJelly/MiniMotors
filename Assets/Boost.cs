using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    public class Boost : MonoBehaviour
    {
        public CarController carController;
        public Rigidbody rbody;

        // Use this for initialization
        void Start()
        {
            carController.GetComponent<CarController>();
        }

        void OnTriggerEnter(Collider other)
        {
            carController.isBoosted = true;
            rbody.drag = 0.01f;
            rbody.mass = 800f;
            Invoke("DisableBooster", 5f);
        }

        void DisableBooster()
        {
            carController.isBoosted = false;
            rbody.drag = 0.1f;
            rbody.mass = 1500f;
        }
    }
}