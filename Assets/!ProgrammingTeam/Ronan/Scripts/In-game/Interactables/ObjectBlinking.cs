using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectBlinking : MonoBehaviour
{
    public Color startColor = Color.black;
    public Color endColor = Color.white;
    [Range(0, 10)]
    public float speed = 1f;
    Renderer render;
    private Color originalColor;
    public float playersReach = 2f;
    float dist;
    public GameObject player;
    public Image handCrosshair; //from canvas

    void Awake()
    {
        render = GetComponent<Renderer>();
        originalColor = render.material.color;
        handCrosshair.enabled = false;
    }

    void OnMouseOver()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= playersReach)
        {
            render.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
            handCrosshair.enabled = true;
        }
        else
        {
            render.material.color = originalColor;
            handCrosshair.enabled = false;
        }
    }
    void OnMouseExit()
    {
        render.material.color = originalColor;
        handCrosshair.enabled = false;
    }
}
