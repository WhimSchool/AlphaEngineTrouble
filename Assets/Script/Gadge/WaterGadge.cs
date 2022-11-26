using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGadge : MonoBehaviour
{
    public Transform gadge;
    private float target;
    private const float levelToDegrees = 270f / 100f;

    void Update()
    {
        target = GetComponentInParent<EngineManager>().waterLevel;
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees);
    }
}
