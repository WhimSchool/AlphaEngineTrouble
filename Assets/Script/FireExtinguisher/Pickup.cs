using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickup : MonoBehaviour
{
    public GameObject Water;
    public GameObject WaterHitbox;
    public ParticleSystem waterParticles;
    public GameObject[] Fuel; 

    public int extinguisherFuel = 9;
    int destroyMeter = 0;
    int timePerSquere = 0;
    int currentMeter;

    void Start()
    {
        currentMeter = Fuel.Length - 1;
        timePerSquere = extinguisherFuel / currentMeter;
        destroyMeter = extinguisherFuel - timePerSquere;

        Water.SetActive(false);
        WaterHitbox.SetActive(false);
    }

    void Update()
    {
        if(extinguisherFuel == destroyMeter)
        {
            destroyMeter = extinguisherFuel - timePerSquere;
            Fuel[currentMeter].gameObject.SetActive(false);
            currentMeter--;
        }
    }

    public void ShootWater()
    {
        if (extinguisherFuel > 0)
        {
            Water.SetActive(true);
            WaterHitbox.SetActive(true);
            waterParticles.Play();
            StartCoroutine("LoseFuel");
        }
    }

    public void StopWater()
    {
        Water.SetActive(false);
        WaterHitbox.SetActive(false);
        waterParticles.Stop();
        StopCoroutine("LoseFuel");
    }

    public IEnumerator LoseFuel()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            extinguisherFuel--;

            if (extinguisherFuel <= 0)
                StopWater();
        }
    }
}
