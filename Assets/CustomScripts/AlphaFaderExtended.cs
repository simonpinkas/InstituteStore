





////////
///////WORK IN PROGRESS
///////















using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AlphaFaderExtended : MonoBehaviour
{

    public float fadeOutStartDelayInSecs = 2.0f;
    public float fadeInStartDelayInSecs = 2.0f;
    public float fadeOutDurationInSecs = 2.0f;
    public float fadeInDurationInSecs = 2.0f;

    //private Renderer r;
    private Color rColor;
    private float currentAlphaValue;
    
    public bool includeChildren = true;

    List<Renderer> targetRenderersDescending;
    List<Renderer> targetRenderersAscending;

    void Start()
    {
        targetRenderersAscending = new List<Renderer>();
        targetRenderersDescending = new List<Renderer>();

        if (GetComponent<Renderer>() != null)
        {
            targetRenderersAscending.Add(GetComponent<Renderer>());
            targetRenderersDescending.Add(GetComponent<Renderer>());
        }

        foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>())
            {
                targetRenderersDescending.Add(r);
                targetRenderersAscending.Add(r);
                //fromChildrenTotal++;
            }
        
        targetRenderersDescending = targetRenderersDescending.OrderByDescending(x => Vector3.Distance(transform.gameObject.gameObject.transform.position, x.transform.position)).ToList();
        targetRenderersAscending = targetRenderersAscending.OrderBy(x => Vector3.Distance(transform.gameObject.gameObject.transform.position, x.transform.position)).ToList();

        //rColor = r.material.color;
        print(targetRenderersDescending);
    }

    void Update()
    {
        //For testing
        ///*
        if (Input.GetKeyUp(KeyCode.R))
        {
            FadeAlphaOut();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            FadeAlphaIn();
        }
        //*/
    }

    //Methods for fading out


    public void FadeAlphaOut()
    {

        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        //fadeOutDurationInSecs = fadeOutDurationInSecsArg;
        foreach (Renderer r in targetRenderersDescending)
        {
            StartCoroutine("FadeOut", r);
        }
    }

    IEnumerator FadeOut (Renderer r)
    {
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeOutDurationInSecs)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 0.0f, t);
            r.material.color = rColor;
            yield return null;
        }
        
    }

    public void FadeAlphaOutDelayed()
    {

        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        //fadeOutStartDelayInSecs = fadeOutStartDelayInSecs;
        StartCoroutine("FadeOutDelayed", fadeOutDurationInSecs);
    }

    IEnumerator FadeOutDelayed(Renderer r)
    {
        //fadeOutDurationInSecs = fadeOutDurationInSecs;
        yield return new WaitForSeconds(fadeOutStartDelayInSecs);

        currentAlphaValue = rColor.a;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeOutDurationInSecs)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 0.0f, t);
            r.material.color = rColor;
            yield return null;
        }
    }
    
    //Methods for fading in

    public void FadeAlphaIn()
    {
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        foreach (Renderer r in targetRenderersAscending)
        {
            StartCoroutine("FadeIn", r);
        }
        }

    IEnumerator FadeIn(Renderer r)
    {
        currentAlphaValue = rColor.a;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeOutDurationInSecs)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 1.0f, t);
            r.material.color = rColor;
            yield return null;
        }
    }
    
    public void FadeAlphaInDelayed()
    {
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        StartCoroutine("FadeInDelayed", fadeInDurationInSecs);
    }

    IEnumerator FadeInDelayed(Renderer r)
    {
        yield return new WaitForSeconds(fadeInStartDelayInSecs);
        currentAlphaValue = rColor.a;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeInDurationInSecs)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 1.0f, t);
            print(rColor.a);
            r.material.color = rColor;
            yield return null;
        }
    }
}










