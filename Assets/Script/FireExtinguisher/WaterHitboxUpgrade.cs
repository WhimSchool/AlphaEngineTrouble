using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHitboxUpgrade : MonoBehaviour
{
    int timeFire = 3;             //Intensity of the fire
    int time = 0;                 //Int varibale to hold the number of times it need to bo water to destroy
    float fireEmmision = 105f;    //float to set the number of emmsisons from the ParticleSystem
    ParticleSystem ps;            //reference to the ParticleSystem varibale

    //Funtion that runs ones per frame
    void Update()
    {
        //Constantly get the ParticleSystem component
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        // Assign the ParticleSystem emmisions to em variable
        var em = ps.emission;
        //Constantly set the emmisions equal to fireEmmision variable
        em.rateOverTime = fireEmmision;

        //If varibale time is equal to 3..
        if (time == 3)
        {
            Destroy(gameObject); //Destroy this GameObject
        }
    }

    //As long as On Trigger Collision is happening...
    private void OnTriggerStay(Collider other)
    {
        //.. if the object in collision has the "WaterHitbox" tag
        if (other.gameObject.tag == "WaterHitbox")
        {
            StartCoroutine("Time");
            if (time == timeFire)
            {
                Destroy(gameObject);
                StopCoroutine("Time");
                time = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            time++;
            fireEmmision -= 35;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Coal")
        {
            Destroy(other.gameObject);
            time--;
            fireEmmision += 35;
        }
    }

    public IEnumerator Time()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
            fireEmmision -= 35;
            if (time > 4)
                time = 0;
        }
    }
}
