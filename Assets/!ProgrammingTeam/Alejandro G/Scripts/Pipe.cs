using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The script needs to be placed in the pipe object
public class Pipe : MonoBehaviour
{
    public bool activePipe;               //A bool that will be used to check if the pipe is connected to an engine
    public bool broken = false;           //A bool that says if the pipe is broken
    public int called = 0;

    public GameObject engine;             //Engine that this pipe is a part of

    public float pressure;                //Steam pressure of said engine
    public float pressureChange;          //Will take the values from the 'sPressureAlter' variable in EngineManager
    public float pressureMin = 100;       //When the steam pressure reaches this value, the pipe will now have the chance to break

    public float rand;                    //Will be a random number

    public float pipeBreakVal;            //When this variable reaches or passes the random variable, the pipe breaks
    public float breakDecreaseLimit;      //When the pressure reaches this value, "pipeBreakVal" will decrease 
    public float breakDecreaseAmount;     //"pipeBreakVal" will lower by this amount, increasing chances of pipe failure

    public float counter = 0;             //When the timer equals to "counterLimit", it will call a function
    public float counterLimit = 10; 
    public float timerSpeed;              //How fast the timer for the pipe will pass; Lower numbers makes timer faster

    public Material brokenMat;            //When the pipe breaks, the material will change to this to indicate that it's broken

    void Update()
    {
        //Checks if the pipe is active
        //If it is active and "called" is at zero, it starts the timer and increases "called" so it doesn't constantly repeat the
        //if statement
        if (activePipe == true && called <= 0)
        {
            StartCoroutine("StartTimer");
            called++;
        }
        //If the pipe is not active, the timer stop and "called" is set back to zero (in case the player is able to remove a pipe
        //even if it isn't broken, it will work again if placed back in)
        else if (activePipe == false)
        {
            StopCoroutine("StartTimer");
            called = 0;
        }

        //The pressure value from the engine that the pipe is connected to is taken and given to the pressure variable here
        pressure = engine.GetComponent<EngineManager>().sPressure;

        //When the timer hits a certain time, it will call the function and set the timer back to zero
        if (counter >= counterLimit)
        {
            counter = 0;
            PipeBreak();
        }

        pressureChange = engine.GetComponent<EngineManager>().sPressureAlter;
    }

    IEnumerator StartTimer()
    {
        //The timer
        while (true)
        {
            yield return new WaitForSeconds(1 * timerSpeed);
            counter++;
        }
    }

    void PipeBreak()
    {
        //If the pressure reaches the minimum value, the pipe will now have the chance to break
        if (pressure > pressureMin)
        {
            //Picks a random number from 0 to 100
            rand = Random.Range(0, 100);

            //If the random number is greater or equal to the breaking value, the pipe 'breaks', changing the material,
            //stopping the timer, and starts decreasing the pressure
            if (rand >= pipeBreakVal)
            {
                this.GetComponent<MeshRenderer>().material = brokenMat;
                StopCoroutine("StartTimer");
                broken = true;
            }
            //If the random value is lower than the breaking value, it sets the random val back to zero
            //(This is to make sure the pipe doesn't immediately break when the breaking value, "pipeBrealVal", is lowered)
            else
            {
                rand = 0;
            }
            
            //If the pressure continues to increase and hits another minimum value, the breaking value will start to lower
            //by a certain amount, making it easier for the pipe to break
            if (pressure >= breakDecreaseLimit)
            {
                pipeBreakVal -= breakDecreaseAmount;
            }

            //Prevents the breaking val from going below 1
            if (pipeBreakVal < 1)
            {
                pipeBreakVal = 1;
            }
        }
        //If it doesn't reach the value, it won't ever break
        else
        {
            return;
        }
    }

    //Activates or deactivates the pipe depending on if the pipe is touching a trigger
    //(Might change this later so it's not hot garbage)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pipe Placeholder")
        {
            activePipe = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pipe Placeholder")
        {
            activePipe = false;

        }
    }
}
