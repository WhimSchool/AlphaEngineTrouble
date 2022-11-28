using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this script where ever the water is going to be poured in the engine. Needs to be a trigger collider

public class Water : MonoBehaviour
{
    //These variables will be copies of the "waterLevel" (fuelAmount), "waterIncrease" (fuelIncrease),
    //and "waterDrainCounter" (timer) vairables in the EngineManager script
    private float fuelAmount;
    private float fuelIncrease;
    private float timer;

    //Constantly takes the values from their respective counterparts and gives them to the new variables
    void Update()
    {
        fuelAmount = GetComponentInParent<EngineManager>().waterLevel;
        fuelIncrease = GetComponentInParent<EngineManager>().waterIncrease;
        timer = GetComponentInParent<EngineManager>().waterDrainCounter;
    }

    //If the fuel is pushed into the trigger, the "water Input", it will destroy the fuel, refill the fuel amount, reset the timer, then send the 
    //values back to the EngineManager script. The bool checking if water was inserted is set to true
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            Destroy(other.gameObject);
            fuelAmount += fuelIncrease;
            timer = 0;
            GetComponentInParent<EngineManager>().waterLevel = fuelAmount;
            GetComponentInParent<EngineManager>().waterDrainCounter = timer;
        }
    }
}
