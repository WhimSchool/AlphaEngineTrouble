using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsLever : MonoBehaviour
{
    Quaternion originalPos;
    float pos;
    public float speed = 1f;

    public LightsOut lights;

    bool goBack = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (goBack == true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * speed);
        }

        if (originalPos == transform.rotation)
            goBack = false;
    }

    public void Stop()
    {
        goBack = false;
    }

    public void MoveBack()
    {
        var x = transform.localEulerAngles.x;

        if (x >= 70)
        {
            goBack = true;

            if (LightsOut.brokenFuse == false)
            {
                lights.NormalLights();
            }
        }
    }
}
