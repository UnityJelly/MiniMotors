using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
    public class PowerUp : MonoBehaviour
    {
        public enum Type
        {
            Boost,
            Slow,
            etc
        };
        //you can make custom powerups from this
        public Type PowerUpType;
        public float Value;
        public float Duration;
        public CarController carController;

        private Transform selfTransform;
        private bool hit;

        void Start()
        {
            //making sure the value is not 0
            Value = (Value == 0) ? 30f : Value;
            //making sure the duration is not 0
            Duration = (Duration == 0) ? 3f : Duration;
            selfTransform = transform;
            hit = false;

        }

        void Update()
        {
            if (!hit)
            {
                ScriptedAnimation(50f);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            //here you must see if your powerup was hit by a player
            GameObject car = other.gameObject;
            if (car)
            {
                //we were hit by a player
                StartCoroutine(carController.SetPowerupValue(Value, Duration));
                Destroy(gameObject);
            }
        }

        void ScriptedAnimation(float speed)
        {
            //rotate around y axis
            selfTransform.eulerAngles += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}