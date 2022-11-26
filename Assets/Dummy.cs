using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dummy : MonoBehaviour
{
    public Slider progress;
    public float num;

    void Update()
    {
        progress.value += num;
    }
}
