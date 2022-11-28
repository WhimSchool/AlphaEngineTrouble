using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script can be in an empty with a trigger collider and it should be where ever the pipe will be placed
public class PipeHolder : MonoBehaviour
{
    public GameObject engine;

    //If the trigger detects a pipe, and said pipe is not 'broken', the engine stops losing pressure and works correctly 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipe" && other.gameObject.GetComponent<Pipe>().broken == false)
        {
            engine.GetComponent<EngineManager>().losingPressure = false;
        }
    }

    //While the pipe is in the trigger, and said pipe is 'broken', the engine will start to lose pressure slowly
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Pipe>().broken == true)
        {
            engine.GetComponent<EngineManager>().losingPressure = true;
        }
        else
        {
            return;
        }
    }

    //If there is no pipe, or if the pipe is removed, the pressure will start decreasing faster
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pipe")
        {
            engine.GetComponent<EngineManager>().losingPressure = true;
        }
    }
}
