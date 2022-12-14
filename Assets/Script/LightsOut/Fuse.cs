using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuse : MonoBehaviour
{
    //On Collision Enter..
    void OnCollisionEnter(Collision other)
    {
        //if the object colliding has the "Fuse" tag
        if (other.gameObject.tag == "Fuse")
        {
            LightsOut.brokenFuse = false;  //Set the brokenFuse bool variable in the LightsOut script
            Destroy(other.gameObject);     //Destroy the colliding GameObject
        }
    }
}
