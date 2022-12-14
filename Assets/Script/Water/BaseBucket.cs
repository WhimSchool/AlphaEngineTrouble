using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBucket : MonoBehaviour
{
    public Bucket handler;
    public ParticleSystem water;
    public ParticleSystem waterOutR;
    public ParticleSystem waterOutL;
    public GameObject waterHitbox;

    public Quaternion desirePos;
    public float speed = 1f;

    float time = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        waterHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var z = transform.eulerAngles.z;
        if (handler.filled == true)
        {
            if (z > 85f && z < 150f) //water falls left to right
            {
                waterOutR.Play();
                waterHitbox.SetActive(true);
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    handler.filled = false;
                    time = 0.5f;
                }
                Invoke("StopWater", 1f);
            }

            if (z > 205f && z < 270f) //water falls right to left
            {
                //Debug.Log("low" + z);
                waterOutL.Play();
                waterHitbox.SetActive(true);
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    handler.filled = false;
                    time = 1;
                }
                Invoke("StopWater", 1.5f);
            }
        }
    }

    public void Show()
    {
        var z = transform.eulerAngles.z;
        waterOutR.Stop();
        waterOutL.Stop();
        Debug.Log(z);
    }

    void StopWater()
    {
        waterOutR.Stop();
        waterOutL.Stop();
        waterHitbox.SetActive(false);
    }

}
