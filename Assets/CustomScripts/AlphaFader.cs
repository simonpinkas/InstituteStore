using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AlphaFader : MonoBehaviour
{
    private float fadeOutStartDelayInSecs;
    private float fadeInStartDelayInSecs;

    private Renderer r;
    private Color rColor;
    private float currentAlphaValue;
    
    void Start()
    {
        r = GetComponent<Renderer>();
        rColor = r.material.color;
    }

    void Update()
    {
        //For testing
        /*
        if (Input.GetKeyUp(KeyCode.R))
        {
            FadeAlphaOutDelayed(2.0f, 3.0f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            FadeAlphaInDelayed(2.0f, 3.0f);
        }
        */
    }
    
    //Methods for fading out

    public void FadeAlphaOut(float fadeOutDurationInSecsArg)
    {
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        StartCoroutine("FadeOut", fadeOutDurationInSecsArg);
    }

    IEnumerator FadeOut(float fadeOutDurationInSecs)
    {
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeOutDurationInSecs)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 0.0f, t);
            r.material.color = rColor;
            yield return null;
        }
    }

    public void FadeAlphaOutDelayed(float fadeOutDurationInSecsArg, float fadeOutStartDelayInSecsArg)
    {

        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        fadeOutStartDelayInSecs = fadeOutStartDelayInSecsArg;
        StartCoroutine("FadeOutDelayed", fadeOutDurationInSecsArg);
    }

    IEnumerator FadeOutDelayed(float fadeOutDurationInSecs)
    {
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

    public void FadeAlphaIn(float fadeOutDurationInSecsArg)
    {
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
       
        StartCoroutine("FadeIn", fadeOutDurationInSecsArg);
    }

    IEnumerator FadeIn(float fadeOutDurationInSecsArg)
    {
        currentAlphaValue = rColor.a;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeOutDurationInSecsArg)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 1.0f, t);
            r.material.color = rColor;
            yield return null;
        }
    }
    
    public void FadeAlphaInDelayed(float fadeInDurationInSecsArg, float fadeInStartDelayInSecsArg)
    {
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOutDelayed");
        StopCoroutine("FadeInDelayed");
        fadeInStartDelayInSecs = fadeInStartDelayInSecsArg;
        StartCoroutine("FadeInDelayed", fadeInDurationInSecsArg);
    }

    IEnumerator FadeInDelayed(float fadeInDurationInSecsArg)
    {
        yield return new WaitForSeconds(fadeInStartDelayInSecs);
        currentAlphaValue = rColor.a;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeInDurationInSecsArg)
        {
            rColor.a = Mathf.Lerp(currentAlphaValue, 1.0f, t);
            print(rColor.a);
            r.material.color = rColor;
            yield return null;
        }
    }
}










