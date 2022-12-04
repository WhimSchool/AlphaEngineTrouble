using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pickup_Andres : MonoBehaviour
{
    public GameObject Equip;
    public GameObject Water;
    public GameObject WaterHitbox;

    public bool FireEquip;
    public int ExtinguisherFuel = 100;
    public Text currentFuel;

    // Start is called before the first frame update
    void Start()
    {
        Water.SetActive(false);
        WaterHitbox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FireEquip == true)
        {
            Equip.SetActive(true);
            if(ExtinguisherFuel >= 20)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Water.SetActive(true);
                    WaterHitbox.SetActive(true);
                    ExtinguisherFuel -= 20;

                }
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Water.SetActive(false);
                    WaterHitbox.SetActive(false);

                }

            }

        }
        currentFuel.text = ("Current Fuel: " + ExtinguisherFuel);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireExtinguisher")
        {
            FireEquip = true;
            Debug.Log("Test");
        }
        //if (other.gameObject.tag == "Fire")
        //{
        //    if (FireEquip == true && ExtinguisherFuel >= 20)
        //    {
        //        Destroy(other.gameObject);
        //        ExtinguisherFuel -= 20;
        //    }
        //}
    }
}
