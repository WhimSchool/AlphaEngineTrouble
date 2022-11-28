using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//For now, this script can just be in an empty object

public class Speed : MonoBehaviour
{
    public Slider shipSpeedVisual;           //The slider that visually shows how much speed the airship currently has
    public float shipSpeed = 0;              //The variable that determines how fast the airship is going
    public float shipSpeedCounter = 0;       //The timer for the ship speed
    public float shipSpeedTime = 5;          //After the timer hits an 'x' amount of time, the ship speed increases
    public float shipSpeedIncrease = 10;     //The variable that controls how much speed will be gained after the time passes
    public float shipSpeedDecrease = 10;     //The variable that controls how much speed will be lossed after the time passes
    public float shipSpeedMultiplier = 1;    //A multiplier for the ships speed that depends on steam pressure

    public GameObject engine1;      //Engine one
    public bool activeEngine1;      //Checking if engine one is active
    public float en1Pressure;       //pressure value of engine one
    public int val1;                //Engine one's portion of the airship speed

    public GameObject engine2;      //Engine two
    public bool activeEngine2;      //Checking if engine two is active
    public float en2Pressure;      //pressure value of engine two
    public int val2;                //Engine two's portion of the airship speed

    public GameObject engine3;      //Engine three
    public bool activeEngine3;      //Checking if engine three is active
    public float en3Pressure;      //pressure value of engine three
    public int val3;                //Engine threes's portion of the airship speed

    public int airshipSpeed;        //The airships max speed depends on how any engines are active. Those numbers are being tracked by the val1-3 variables

    void Update()
    {
        //Calls these functions and matches the slider value with the variable's value 
        MaxSpeedController();
        SpeedControl();
        SetVal();
        shipSpeedVisual.value = shipSpeed;
    }

    void SetVal()
    {
        //Takes the pressure value's from each engine and gives it to their respective variables for this script
        en1Pressure = engine1.GetComponent<EngineManager>().sPressure;
        en2Pressure = engine2.GetComponent<EngineManager>().sPressure;
        en3Pressure = engine3.GetComponent<EngineManager>().sPressure;
    }

    void SpeedControl()
    {
        //The ship's speed is the sum of all three engine's pressure values divided by three
        shipSpeed = (en1Pressure + en2Pressure + en3Pressure) / 3;

        //Prevents the speed from dropping below zero
        if (shipSpeed < 0)
        {
            shipSpeed = 0;
        }

        //Prevents the speed from rising above 100
        if (shipSpeed > 100)
        {
            shipSpeed = 100;
        }
    }

    void CheckingActiveEngines()
    {
        //Checking to see if each engine is active. If an engine is active, they set the val variables to 1.
        activeEngine1 = engine1.GetComponent<EngineManager>().activeEngine;
        activeEngine2 = engine2.GetComponent<EngineManager>().activeEngine;
        activeEngine3 = engine3.GetComponent<EngineManager>().activeEngine;


        //If an engine is disabled, it sets val to 0
        if (activeEngine1 == true)
        {
            val1 = 1;
        }
        else
        {
            val1 = 0;
        }

        if (activeEngine2 == true)
        {
            val2 = 1;
        }
        else
        {
            val2 = 0;
        }

        if (activeEngine3 == true)
        {
            val3 = 1;
        }
        else
        {
            val3 = 0;
        }
    }

    void MaxSpeedController()
    {
        //Calls the two previous functions and adds up all val variables together into airshipSpeed.
        CheckingActiveEngines();
        airshipSpeed = (val1 + val2 + val3);

        //Prevents the speed from going negative
        if (airshipSpeed < 0)
        {
            airshipSpeed = 0;
        }

        //If airshipSpeed is at 0, then the maximum speed of the airship is set to 0 and its current speed slows down to match it.
        if (airshipSpeed == 0)
        {
            if (shipSpeed > 1)
            {
                shipSpeed = shipSpeed - (shipSpeedIncrease * shipSpeedMultiplier);
            }
        }
        //If airshipSpeed is at 1, then the maximum speed is now 1/3 of the original max speed
        else if (airshipSpeed == 1)
        {
            if (shipSpeed > (100 / 3))
            {
                shipSpeed = shipSpeed - (shipSpeedIncrease * shipSpeedMultiplier);
            }

            if (shipSpeed < (100 / 3))
            {
                shipSpeed = shipSpeed + (shipSpeedIncrease * shipSpeedMultiplier);
            }
        }
        //When it's at 2, then the max is now 2/3 of the original
        else if (airshipSpeed == 2)
        {
            if (shipSpeed > (2 * (100 / 3)))
            {
                shipSpeed = shipSpeed - (shipSpeedIncrease * shipSpeedMultiplier);
            }

            if (shipSpeed < (2 * (100 / 3)))
            {
                shipSpeed = shipSpeed + (shipSpeedIncrease * shipSpeedMultiplier);
            } 
        }

        //If it's at 3, then the airship can go at full speed.
        else
        {
            shipSpeed = shipSpeed + (shipSpeedIncrease * shipSpeedMultiplier);

            if (shipSpeed > 100)
            {
                shipSpeed = 100;
            } 
        }
        //After the speed is set, the values are sent back to the EngineManager script
    }
}
