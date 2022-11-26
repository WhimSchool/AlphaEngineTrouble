using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private bool hit = true;

    //On Trigger Exit collision..
    void OnTriggerExit(Collider other)
    {
        //If the gameObject with the shovel tag exits the trigger collidion...
        if (other.gameObject.tag == "Shovel")
        {
            if (hit == true)  //Make sure it does the followinf commands only once
            {
                Invoke("DestroyO", 0.2f); //..invokes the DestroyO function with a delay of 0.5 seconds
                hit = false;  //Make sure it does the followinf commands only once
            }
        }
    }

    void DestroyO()
    {
        Destroy(gameObject);  //Destroy this Game Object
    }
}
