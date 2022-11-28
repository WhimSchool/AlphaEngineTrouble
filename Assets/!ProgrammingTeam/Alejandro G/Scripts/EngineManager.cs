using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Place this script in the engine object

public class EngineManager : MonoBehaviour
{
    public GameObject coalInput;             //The part of the engine the coal has to enter before being used
    public Slider coalLevelVisual;           //The slider that visually shows how much coal is left in the engine
    public float coalLevel = 100;            //The variable that determines how much coal is left in the engine
    public float coalDrainCounter = 0;       //The timer for the coal
    public float coalDrainTime = 5;          //After the timer hits an 'x' amount of time, the coal is drained
    public float coalDrainAmount = 10;       //The variable that controls how much of the coal will be drained after the time passes
    public float coalIncrease = 50;          //Controls how much coal will be added into the engine when put in

    public GameObject waterInput;            //The part of the engine the water has to enter before being used
    public Slider waterLevelVisual;          //The slider that visually shows how much water is left in the engine
    public float waterLevel = 100;           //The variable that determines how much water is left in the engine
    public float waterDrainCounter = 0;      //The timer for the water
    public float waterDrainTime = 5;         //After the timer hits an 'x' amount of time, the water is drained
    public float waterDrainAmount = 10;      //The variable that controls how much of the water will be drained after the time passes
    public float waterIncrease = 50;         //Controls how much water will be added into the engine when put in

    public Slider sPressureVisual;           //The slider that visually shows how much steam pressure has been built up
    public float sPressure = 0;              //The variable that determines how much steam there is
    public float sPressureCounter = 0;       //The timer for the steam pressure
    public float sPressureTime = 5;          //After the timer hits an 'x' amount of time, the steam pressure increases
    public float sPressureAlter = 10;        //The variable that controls how much pressure will build up or lower after the time passes
    public float sPressureMultiplier = 1;    //Makes the steam pressure rise faster or slower depending on coal level

    public bool losingPressure = false;      //Checks if a pipe for the engine has broken and now losing pressure

    public float timerSpeed = 1;             //How fast ALL timers in the ENGINE will pass; Lower numbers makes timer faster
    public bool activeEngine = true;         //Checks if the engine is currently running. A running engine must have coal AND water 

    void Start()
    {
        StartCoroutine("StartTimers");
    }

    void Update()
    {
        //Sets the sliders' value to that of the variables that control the values (ex. coal slider value is set to coal level value)
        coalLevelVisual.value = coalLevel;
        waterLevelVisual.value = waterLevel;
        sPressureVisual.value = sPressure;
    }

    //Starts all of the timers in the script
    IEnumerator StartTimers()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 * timerSpeed);
            CoalDrain();
            WaterDrain();
            PressureControl();
        }
    }

    //Function that controls the coal level of the engine, along with the Coal script
    void CoalDrain()
    {
        coalDrainCounter++;

        //When the counter hits the desired time, it will decrease the coal and reset the counter
        if (coalDrainCounter >= coalDrainTime)
        {
            coalLevel = coalLevel - coalDrainAmount;
            coalDrainCounter = 0;
        }

        //Prevents the coal level to drop below zero
        if (coalLevel < 0)
        {
            coalLevel = 0;
        }
    }

    //Function that controls the water level of the engine, along with the Water script
    void WaterDrain()
    {
        waterDrainCounter++;

        //When the counter hits the desired time, it will decrease the water and reset the counter
        if (waterDrainCounter >= waterDrainTime)
        {
            waterLevel = waterLevel - waterDrainAmount;
            waterDrainCounter = 0;
        }

        //Prevents the water level to drop below zero
        if (waterLevel < 0)
        {
            waterLevel = 0;
        }
    }

    //Function that controls the steam pressure of the engine
    void PressureControl()
    {
        //The speed of the pressure increase is raised by 50% if the engine has more than 75% coal levels,
        //while the speed of the pressure increase is dropped by 50% if the engine has less than 25% coal levels  
        if (coalLevel > 95)
        {
            sPressureMultiplier = 1.5f;
        }
        else if (coalLevel < 25)
        {
            sPressureMultiplier = 0.5f;
        }
        else
        {
            sPressureMultiplier = 1;
        }

        //If there is any amount of water AND coal in engine, the counter increases and the pressure rises. If not, the pressure drops
        if (waterLevel > 0 && coalLevel > 0)
        {
            sPressureCounter++;

            //If a pipe is broken or not connected, the engine starts losing pressure
            if (losingPressure == true)
            {
                //When the counter hits the desired time, it will decrease the pressure and reset the counter
                if (sPressureCounter >= sPressureTime)
                {
                    sPressure = sPressure - (sPressureAlter / 5);
                    sPressureCounter = 0;
                }
            }
            //When the counter hits the desired time, it will increase the pressure and reset the counter
            else if (sPressureCounter >= sPressureTime)
            {
                sPressure = sPressure + (sPressureAlter * sPressureMultiplier);
                sPressureCounter = 0;

                activeEngine = true;
            }
        }
        //If there no water OR coal in engine, the engine is shut off
        else
        {
            //If a pipe is broken or not connected, the engine starts losing pressure
            if (losingPressure == true)
            {
                sPressureCounter++;

                //When the counter hits the desired time, it will decrease the pressure and reset the counter
                if (sPressureCounter >= sPressureTime)
                {
                    sPressure = sPressure - (sPressureAlter / 2);
                    sPressureCounter = 0;
                }
            }

            activeEngine = false;
        }

        //Prevents the pressure from dropping below zero
        if (sPressure < 0)
        {
            sPressure = 0;
        }

        //Prevents the pressure from raising above 150
        if (sPressure > 150)
        {
            sPressure = 150;
        }
    }
}
