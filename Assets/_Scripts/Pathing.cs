using UnityEngine;
using System.Collections;

public class Pathing : MonoBehaviour
{

    private int LayerGround;
    private bool CastRays = true; 

    void Start()
    {
        LayerGround = LayerMask.NameToLayer("Track");
    }

    void FixedUpdate()
    {
        if (CastRays)
        {

            RaycastHit hit;
            
            // Raycast
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 10f))
            {

                if (hit.transform.gameObject.layer == LayerGround)
                {
                    Debug.Log("Ground");
                    // Make a path
                }
                else
                {
                    Debug.Log("Other Objects");
                    Debug.DrawLine(transform.position, hit.point);
                    // Do whatever you want
                }
            }
        }
    }
}