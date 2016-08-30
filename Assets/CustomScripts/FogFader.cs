using UnityEngine;
using System.Collections;

public class FogFader : MonoBehaviour
{
    private float fadeInDurationSecs;
    private float fadeOutDurationSecs;

    private float onStartDensity;
    private float currentDensity;

    private float fadeInDelaySecs;
    private float fadeOutDelaySecs;

    void Start()
    {
    onStartDensity = RenderSettings.fogDensity;
    currentDensity = RenderSettings.fogDensity;
    }

//Delete Update() when done with script
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            FadeFogOut(fadeOutDurationSecs);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            FadeFogIn(fadeOutDurationSecs);
        }
    }

    public void FadeFogOut(float fadeDurationSecsArg)
    {
        print("FadeFogOut() Duration:" + fadeDurationSecsArg.ToString());
        fadeOutDurationSecs = fadeDurationSecsArg;
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StartCoroutine(FadeOut(fadeOutDurationSecs));
    }

    public void FadeFogOutDelayed(float fadeDurationSecsArg, float delayTimeSecsArg)
    {
        fadeOutDurationSecs = fadeDurationSecsArg;
        fadeOutDelaySecs = delayTimeSecsArg;
        Invoke("FadeFogOut", fadeOutDelaySecs);
    }

    public void FadeFogIn(float fadeDurationSecsArg)
    {
        fadeOutDurationSecs = fadeDurationSecsArg;
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOut");
        StartCoroutine(FadeIn(fadeOutDurationSecs));
    }

    public void FadeFogInDelayed(float fadeDurationSecsArg, float delayTimeSecsArg)
    {
        fadeInDurationSecs = fadeDurationSecsArg;
        fadeInDelaySecs = delayTimeSecsArg;
        Invoke("FadeFogIn", fadeInDelaySecs);
    }

    IEnumerator FadeOut(float fadeOutDurationSeconds)
    {
        currentDensity = RenderSettings.fogDensity;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeOutDurationSeconds)
        {
            RenderSettings.fogDensity = Mathf.Lerp(onStartDensity, 0.0f, t);
            Debug.Log("FadeOut RenderSettings.fogDensity:" + RenderSettings.fogDensity);
            yield return null;
        }
    }

    IEnumerator FadeIn(float fadeInDurationSeconds)
    {
        currentDensity = RenderSettings.fogDensity;
        for (float t = 0; t < 1.0f; t += Time.deltaTime / fadeInDurationSeconds)
        {
            RenderSettings.fogDensity = Mathf.Lerp(0.0f, onStartDensity, t);
            Debug.Log("FadeIn RenderSettings.fogDensity:" + RenderSettings.fogDensity);
            yield return null;
        }
    }
}