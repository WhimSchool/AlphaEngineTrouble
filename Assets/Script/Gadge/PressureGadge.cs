using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureGadge : MonoBehaviour
{
    public Transform gadge;
    public Pressure pressure;
    private float target;
    private const float levelToDegrees = 270f / 100f;

    void Update()
    {
        target = pressure.sPressure;
        gadge.localRotation = Quaternion.Euler(0f, 0f, (float)target * -levelToDegrees);
    }
}
