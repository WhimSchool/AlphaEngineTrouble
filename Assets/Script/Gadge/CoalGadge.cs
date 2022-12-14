using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalGadge : MonoBehaviour
{
    public Transform gadge;  //Reference to the Gadge GameObject
    private float target;    //Float to set the position of the Gadge
    private const float levelToDegrees = 270f / 100f;  

    void Update()
    {
        target = GetComponentInParent<EngineManager_Ariel>().coalLevel;  
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees);
    }
}
