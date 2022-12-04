using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorSystem : MonoBehaviour
{
    public int rng = 1;
    public bool needsOil = false;

    //timer related code
    public int timeLeft = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("oil"))
        {
            gameObject.SetActive(false); //remove this when importing to VR/actual game
            //transform/play door open animation
            timeLeft = 5;
            StartCoroutine("LoseTime");
            if (timeLeft <= 0)
            {
                StopCoroutine("LoseTime");
                //transform/play door close animation
            }
            needsOil = false;
        }
        if (other.CompareTag ("Player"))
        {
            if (needsOil == false)
            {
                rng = Random.Range(1, 6);
                if (rng == 1)
                {
                    needsOil = true;
                    Debug.Log("Needs Oil");
                }
                else if (rng == 2 || rng == 3 || rng == 4 || rng == 5 || rng == 6)
                {
                    gameObject.SetActive(false); //remove this when importing to VR/actual game
                                                 //transform/play door open animation
                    timeLeft = 5;
                    StartCoroutine("LoseTime");
                    if (timeLeft <= 0)
                    {
                        StopCoroutine("LoseTime");
                        //transform/play door close animation
                    }
                    Debug.Log("Open");

                }
            }
            

            else if (needsOil == true)
            {
                rng = 1;
            }
        }
    }

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }

}
