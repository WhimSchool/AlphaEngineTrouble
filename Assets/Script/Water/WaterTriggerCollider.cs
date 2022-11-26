using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTriggerCollider : MonoBehaviour
{
    public WaterValve valve;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bucket")
        {
            valve.bucketInPlace = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bucket")
        {
            valve.bucketInPlace = false;
        }
    }
}
