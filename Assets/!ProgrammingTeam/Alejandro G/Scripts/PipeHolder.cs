using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script can be in an empty with a trigger collider and it should be where ever the pipe will be placed
public class PipeHolder : MonoBehaviour
{
    public GameObject engine;

    public AudioSource losingSteam;       //This sound will play and loop to let the player know that a pipe is losing pressure
    public AudioClip[] lsSounds;          //All of the sounds that can play when the pressure is decreasing
    public int soundRand;                //A number that will randomly decide which clip to play from the lsSounds
    public int i = 0;

    void Update()
    {
        if (engine.GetComponent<EngineManager>().losingPressure == true)
        {
            RandomPressureLossSound();
        }
        else if (engine.GetComponent<EngineManager>().losingPressure == false)
        {
            losingSteam.mute = true;
        }
    }

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

    //Plays a sound when there is still steam left
    //Needs an audio source to play from
    void RandomPressureLossSound()
    {
        if (engine.GetComponent<EngineManager>().sPressure > 0 && i <= 1)
        {
            losingSteam.mute = false;
            soundRand = Random.Range(0, lsSounds.Length);
            losingSteam.clip = lsSounds[soundRand];
            losingSteam.Play();
            i++;
        }

        if (engine.GetComponent<EngineManager>().sPressure <= 0)
        {
            losingSteam.mute = true;
            i = 1;
        }
    }
}
