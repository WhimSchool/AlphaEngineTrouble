using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBucket : MonoBehaviour
{

    public Slider water;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        


    }
    
    
    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Water")
        {
            Debug.Log("Stay");
            water.value += 1;

        }

    }
}
