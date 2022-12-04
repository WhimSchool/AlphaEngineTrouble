using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastObjectBlinking : MonoBehaviour
{
    public Camera playerCam;
    public float distance = 2f;
    RaycastHit hit;
    Ray ray;


    public Color startColor = Color.black;
    public Color endColor = Color.white;
    [Range(0, 10)]
    public float speed = 2f;
    Renderer render;
    private Color originalColor;
    public Image handCrosshair; //from canvas
    private Transform _selected;

    void Awake()
    {
        render = GetComponent<Renderer>();
        originalColor = render.material.color;
        handCrosshair.enabled = false;
    }
    void Update()
    {
        if (_selected != null)
        {
            var selectionRender = _selected.GetComponent<Renderer>();
            selectionRender.material.color = originalColor;
            _selected = null;
            handCrosshair.enabled = false;
        }

        ray = playerCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, distance))
        {

            var selected = hit.transform;
            if (selected.transform.tag == "Interactable")
            {
                var selectedRenderer = selected.GetComponent<Renderer>();
                if (selectedRenderer != null)
                {
                    selectedRenderer.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
                    handCrosshair.enabled = true;

                }
                _selected = selected;
            }
        }
    }
}

