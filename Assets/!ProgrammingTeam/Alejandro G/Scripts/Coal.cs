using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Place this script where ever the coal is going to be shovelled in the engine. Needs to be a trigger collider

public class Coal : MonoBehaviour
{
    //These variables will be copies of the "coalLevel" (fuelAmount), "coalIncrease" (fuelIncrease),
    //and "coalDrainCounter" (timer) vairables in the EngineManager script
    private float fuelAmount;
    private float fuelIncrease;
    private float timer;

    //Constantly takes the values from their respective counterparts and gives them to the new variables
    void Update()
    {
        fuelAmount = GetComponentInParent<EngineManager>().coalLevel;
        fuelIncrease = GetComponentInParent<EngineManager>().coalIncrease;
        timer = GetComponentInParent<EngineManager>().coalDrainCounter;
    }

    //If the fuel is pushed into the trigger, the "Coal Input", it will destroy the fuel, refill the fuel amount, reset the timer, then send the 
    //values back to the EngineManager script. The bool checking if coal was inserted is set to true
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coal")     
        {
            Destroy(other.gameObject);
            fuelAmount = fuelAmount + fuelIncrease;
            timer = 0;
            GetComponentInParent<EngineManager>().coalLevel = fuelAmount;
            GetComponentInParent<EngineManager>().coalDrainCounter = timer;
        }
    }
}
