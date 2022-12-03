using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchRaycast : MonoBehaviour
{
    public GameObject pipe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {

            if (hit.collider.tag == "pipe" && Input.GetKeyDown(KeyCode.E))
            {

                RotatePipe();
                Debug.Log("Pipe hit");

            }

        }

    }
    void RotatePipe()
    {

        pipe.transform.Rotate(0, 10, 0, Space.Self);

    }
}
