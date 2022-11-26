using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterValve : MonoBehaviour
{
    Quaternion originalPos;
    public float speed = 1f;

    public ParticleSystem water;
    public ParticleSystem waterWhite;

    public float minValue = 0;
    public float maxvalue = 0;

    private bool letPlay;// = false;
    public bool bucketInPlace = false;

    public Bucket bucket;
    private bool fill = false;
    private bool startTimeToFill = false;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        var x = transform.localEulerAngles.x;

        if (startTimeToFill == true)
        {
            time += 0.05f;
            if (time >= 2f)
            {
                fill = true;
                startTimeToFill = false;
                time = 0;
            }
        }
        if (bucketInPlace)
        {
            if (x > minValue && x < maxvalue)
            {
                letPlay = false;
            }
            else
            {
                letPlay = true;
                startTimeToFill = true;
            }
        }
        else
        {
            letPlay = false;
        }

        if (letPlay)
        {
            if (!water.isPlaying)
            {
                water.Play();
                waterWhite.Play();
            }
        }
        else
        {
            if (water.isPlaying)
            {
                water.Stop();
                waterWhite.Stop();
            }
        }

        if (fill == true)
        {
            bucket.filled = true;
            fill = false;
        }
    }

    public void MoveBack()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalPos, Time.time * speed);
    }
}
