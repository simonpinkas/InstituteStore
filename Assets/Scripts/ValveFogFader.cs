using UnityEngine;
using System.Collections;

public class ValveFogFader : MonoBehaviour
{

    public ValveFog valveFog;

    float currentFade;
    
    private float onStartDist;
    private float onEndDist;

    //public float offStartDist = 100;
    //public float offEndDist = 100;

    void Start()
    {
        currentFade = 0.0f;
        onStartDist = valveFog.startDistance;
        onEndDist = valveFog.endDistance;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            FadeFogOut(3.0f);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            FadeFogIn(3.0f);
        }
    }

    public void FadeFogOut(float duration)
    {
        StopCoroutine("FadeOut");
        StopCoroutine("FadeIn");
        StartCoroutine(FadeOut(duration));
    }

    public void FadeFogIn(float duration)
    {
        StopCoroutine("FadeIn");
        StopCoroutine("FadeOut");
        StartCoroutine(FadeIn(duration));
    }


    IEnumerator FadeOut(float dTime)
    {
        //onStartDist = valveFog.startDistance;
        //onEndDist = valveFog.endDistance;
    
        for (float t = currentFade; t <= 1.0f; t += Time.deltaTime / dTime)
        {
            valveFog.startDistance = Mathf.Lerp(onStartDist, 100, t);
            valveFog.endDistance = Mathf.Lerp(onEndDist, 100, t);
            currentFade = t;
            print(currentFade);
            yield return null;
        }
    }

    IEnumerator FadeIn(float dTime)
    {
        //onStartDist = valveFog.startDistance;
        //onEndDist = valveFog.endDistance;
      
        for (float t = currentFade; t > 0.0f; t -= Time.deltaTime / dTime)
        {
            valveFog.startDistance = Mathf.Lerp(onStartDist, 100, t);
            valveFog.endDistance = Mathf.Lerp(onEndDist, 100, t);
            currentFade = t;
            print(currentFade);
            yield return null;
        }
    }
}