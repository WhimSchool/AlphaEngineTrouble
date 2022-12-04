using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHitbox : MonoBehaviour
{
    public GameObject hitbox;
    public GameObject Water;

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
        if (other.gameObject.tag == "Fire")
        {
            Destroy(other.gameObject);
            hitbox.SetActive(false);
            Water.SetActive(false);
        }
    }
}
