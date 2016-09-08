using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RendererEnabler : MonoBehaviour
{
    [Header("Add Renderers")]
    public bool fromChildren = true;
    public GameObject fromChildrenOf;
    public bool byTag = false;
    public string targetTag;

    [Header("Scene Start Settings")]
    public StateAtSceneStart stateAtSceneStart;
    public enum StateAtSceneStart
    {
        Disabled,
        Enabled,
        EnabledDelayed,
        IntervalEnable,
        IntervalEnableDelayed
    };
    public float sceneStartDelayTimeInSeconds;

    [Header("Enabler Settings")]
    public EnablerTimeMode enablerTimeMode;
    public enum EnablerTimeMode { transitionTime, intervalTime };
    public float enablerTransitionTime = 5f;
    public float enablerIntervalTime = .01f;
    public int enablesPerInterval = 1;
    private float finalEnableInterval;
   
    [Header("Disabler Settings")]
    public DisablerTimeMode disablerTimeMode;
    public enum DisablerTimeMode { transitionTime, intervalTime };
    public float disablerTransitionTime = 5f;
    public float disablerIntervalTime = .01f;
    public int disablesPerInterval = 1;
    private float finalDisableInterval;

    private int fromChildrenTotal = 0;
    private int fromChildrenOfTotal = 0;
    private int byTagTotal = 0;

    private string addRenderersInChildrenOfname;

    private GameObject origin;
    List<GameObject> targetGameObjects;
    List<Renderer> targetRenderersDescending;
    List<Renderer> targetRenderersAscending;

    void Start()
    {
        // Collect Renderers
        targetRenderersDescending = new List<Renderer>();
        targetRenderersAscending = new List<Renderer>();
        targetGameObjects = new List<GameObject>();
        origin = GameObject.Find("Origin");

        if (fromChildren)
        {
            foreach (Renderer r in gameObject.GetComponentsInChildren<Renderer>())
            {
                targetRenderersDescending.Add(r);
                targetRenderersAscending.Add(r);
                fromChildrenTotal++;
            }
        }

        if (fromChildrenOf != null)
        {
            foreach (Renderer r in fromChildrenOf.GetComponentsInChildren<Renderer>())
            {
                targetRenderersDescending.Add(r);
                targetRenderersAscending.Add(r);
            }
            addRenderersInChildrenOfname = fromChildrenOf.name;
            fromChildrenOfTotal++;
        }

        else
        {
            addRenderersInChildrenOfname = "none";
        }


        if (byTag)
        {
            targetGameObjects = GameObject.FindGameObjectsWithTag(targetTag).ToList();
            for (int i = 0; i < targetGameObjects.Count; i++)
            {
                print(targetGameObjects.ElementAt(i));
                targetRenderersDescending.Add(targetGameObjects.ElementAt(i).GetComponent<Renderer>());
                targetRenderersAscending.Add(targetGameObjects.ElementAt(i).GetComponent<Renderer>());
            }
            byTagTotal++;
        }

        targetRenderersDescending = targetRenderersDescending.OrderByDescending(x => Vector3.Distance(transform.gameObject.gameObject.transform.position, x.transform.position)).ToList();
        targetRenderersAscending = targetRenderersAscending.OrderBy(x => Vector3.Distance(transform.gameObject.gameObject.transform.position, x.transform.position)).ToList();


        //print("RENDERERS READY fromChildren:" + fromChildrenTotal + " fromChildrenOf:" + fromChildrenOfTotal + " byTag:" + byTagTotal);


        if (enablerTimeMode == EnablerTimeMode.transitionTime)
        {
            finalEnableInterval = enablerTransitionTime / targetRenderersDescending.Count;
        }
        else
        {
            finalEnableInterval = enablerIntervalTime;
        }

        if (disablerTimeMode == DisablerTimeMode.intervalTime)
        {
            finalDisableInterval = disablerTransitionTime / targetRenderersDescending.Count;
        }
        else
        {
            finalDisableInterval = disablerIntervalTime;
        }
        
        // Renderer start States
        switch (stateAtSceneStart)
        {
            case StateAtSceneStart.Disabled:
                DisableTargetsAllNow();
                break;
            case StateAtSceneStart.Enabled:
                EnableTargetsAllNow();
                break;
            case StateAtSceneStart.EnabledDelayed:
                DisableTargetsAllNow();
                EnableTargetsAllDelayed(sceneStartDelayTimeInSeconds);
                break;
            case StateAtSceneStart.IntervalEnable:
                DisableTargetsAllNow();
                IntervalEnableTargets();
                break;
            case StateAtSceneStart.IntervalEnableDelayed:
                DisableTargetsAllNow();
                DisableTargetsAllDelayed(sceneStartDelayTimeInSeconds);
                break;
        }
    }
    
    // Methods
    public void EnableTargetsAllNow()
    {
        for (int i = 0; i < targetRenderersAscending.Count; i++)
        {
            targetRenderersAscending.ElementAt(i).enabled = true;
        }
    }

    public void EnableTargetsAllDelayed(float delayTimeSecsArg)
    {
        Invoke("EnableTargetsAllNow", delayTimeSecsArg);
    }
    
    public void DisableTargetsAllNow()
    {
        for (int i = 0; i < targetRenderersDescending.Count; i++)
        {
            targetRenderersDescending.ElementAt(i).enabled = false;
        }
    }

    public void DisableTargetsAllDelayed(float delayTimeSecsArg)
    {
        Invoke("DisableTargetsAllNow", delayTimeSecsArg);
    }

    public void IntervalEnableTargets()
    {
        StopCoroutine("DeactivateTargetsCoroutine");
        StartCoroutine("ActivateTargetsCoroutine");
        Debug.Log("Interval Enable: " + gameObject.name);
    }

    public void IntervalEnableTargetsDelayed(float delayTimeSecsArg)
    {
        Invoke("IntervalEnableTargets", delayTimeSecsArg);
    }

    public void IntervalDisableTargets()
    {
        StopCoroutine("ActivateTargetsCoroutine");
        StartCoroutine("DeactivateTargetsCoroutine");
        Debug.Log("Interval Disable: " + gameObject.name);
    }

    public void IntervalDisableTargetsDelayed(float delayTimeSecsArg)
    {
        Invoke("IntervalDisableTargets", delayTimeSecsArg);
    }

    IEnumerator ActivateTargetsCoroutine()
    {
        for (int i = 0; i < targetRenderersDescending.Count; i += enablesPerInterval)
        {
            for (int e = 0; e <= enablesPerInterval && i+e < targetRenderersDescending.Count; e++)
            {
                
                targetRenderersDescending.ElementAt(i+e).enabled = true;
            }

            yield return new WaitForSeconds(finalEnableInterval);
        }
    }

    IEnumerator DeactivateTargetsCoroutine()
    {
        for (int i = 0; i < targetRenderersAscending.Count; i += disablesPerInterval)
        {
            for (int e = 0; e <= disablesPerInterval; e++)

            {
                targetRenderersAscending.ElementAt(i+e).enabled = false;
            }

            yield return new WaitForSeconds(finalDisableInterval);
        }
    }
    
    /*
    IEnumerator FadeTo(Renderer r, float aValue, float aTime)
    {
        float alpha = r.material.color.a;
        for (float t = 0.0f; t < 1.0f ; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            r.material.color = newColor;
            yield return null;
        }
    }
    */

}











