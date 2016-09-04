using UnityEngine;
using System.Collections;

public class AlphaFade : MonoBehaviour
{

    public float alphaValue = 0.0f;
    Color rColor;

    void Start()
    {
        rColor = GetComponent<Renderer>().material.color;
        rColor.a = alphaValue;
        GetComponent<Renderer>().material.color = rColor;
    }

    void Update()
    {

    }

}