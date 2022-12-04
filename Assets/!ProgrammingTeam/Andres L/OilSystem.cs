using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("oil"))
        {
            Destroy(other.gameObject);
            gameObject.tag = "oil";
        }
    }
}
