using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBetweenWrench : MonoBehaviour
{
    public GameObject pipe;
    public GameObject upperWrench;
    public GameObject lowerWrench;

    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "lowerWrench" && collision.gameObject.tag == "upperWrench" && Input.GetKeyDown(KeyCode.E))
        {

            RotatePipe();
            Debug.Log("Pipe hit");

        }

    }
    void RotatePipe()
    {

        pipe.transform.Rotate(0, 10, 0, Space.Self);

    }
}
