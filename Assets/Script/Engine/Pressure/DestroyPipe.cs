using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPipe : MonoBehaviour
{
    public GameObject pipe;    //Obejct to hide on collision
    public GameObject holder;  //Change variable in Parent

    Rigidbody rb;              //Variable for hammer Rigidgody

    void OnCollisionEnter(Collision other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();  //Assign Rigidbody to variable on collision

        //If the oject collising is the hummer and it velocity is higher the 3f
        if (other.gameObject.tag == "Hammer" && rb.velocity.magnitude > 3f)
        {
            pipe.SetActive(false);   //Set the broken pipe Object as false
            //Set the brokenPipeActive bool varibale in FixedPipeHandler script as false
            holder.GetComponent<FixedPipeHandler>().brokenPipeActive = false;
        }
    }
}
