using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class HoveringText : MonoBehaviour
{
    public string objName;
    public TMP_Text text;
    public float textHeight = 0.05f;
    public float playersReach = 2f;
    float dist;
    public GameObject player;

    void Start()
    {
        text.gameObject.SetActive(false);
    }

     void OnMouseOver()
    {
        text.text = objName;
        //Move text to any object attached with this script
        text.transform.position = transform.position + new Vector3(0, textHeight, 0);

        //text.transform.LookAt(2 * text.transform.position - Camera.main.transform.position); //Still text
        text.transform.rotation = Camera.main.transform.rotation; //Text rotates with camera. See which one you like best

        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= playersReach)
        {
            text.gameObject.SetActive(true);
        }
    }
     public void OnMouseExit()
    {
        text.gameObject.SetActive(false);
    }

    //Potential fix needed: Position the text to the top of the objects, not the center.
}
