using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class RendererEnablerExtended : MonoBehaviour
{
    [Header("Add Renderers:")]
    public bool fromChildren = true;
    public GameObject fromChildrenOf;
    public bool byTag = false;
    public string targetTag;

    [Header("Scene Start Settings")]
    public StateAtSceneStart stateAtSceneStart;
    public enum StateAtSceneStart { intervalEnable, intervalEnableDelayed, enabled, enabledDelayed, inactive };
    public float delayTimeInSeconds = 0f;

    [Header("Enable Settings")]
    public float transitionTime = 5f;
    public enum EnableTimeMode { transitionTime, intervalTime };
    public EnableTimeMode enableTimeMode;
    public float enableIntervalTime = .01f;
    public int enablesPerInterval = 1;
    public float finalEnableInterval;
    //public int enablesPerInterval = 3;

    [Header("Disable Settings")]
    public float disableTransitionTime = 5f;
    public enum DisableTimeMode { transitionTime, intervalTime };
    public DisableTimeMode disableTimeMode;
    public float disableIntervalTime = .01f;
    public int disablesPerInterval = 1;
    public float finalDisableInterval;
    //public int disablesPerInterval = 3;

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


        print("RENDERERS READY fromChildren:" + fromChildrenTotal + " fromChildrenOf:" + fromChildrenOfTotal + " byTag:" + byTagTotal);


        if (enableTimeMode == EnableTimeMode.transitionTime)
        {
            finalEnableInterval = transitionTime / targetRenderersDescending.Count;
        }
        else
        {
            finalEnableInterval = enableIntervalTime;
        }

        if (disableTimeMode == DisableTimeMode.intervalTime)
        {
            finalDisableInterval = disableTransitionTime / targetRenderersDescending.Count;
        }
        else
        {
            finalDisableInterval = disableIntervalTime;
        }
        
        if (stateAtSceneStart == StateAtSceneStart.intervalEnable)
        {
            DisableTargetsImmediately();
            IntervalEnableTargets();
        }
        else if (stateAtSceneStart == StateAtSceneStart.intervalEnableDelayed)
        {
            DisableTargetsImmediately();
            Invoke("IntervalTargets", delayTimeInSeconds);
        }
        else if (stateAtSceneStart == StateAtSceneStart.enabled)
        {
            EnableTargetsImmediate();
        }
        else if (stateAtSceneStart == StateAtSceneStart.enabledDelayed)
        {
            DisableTargetsImmediately();
            Invoke("EnableTargetsImmediately", delayTimeInSeconds);
        }
        else if (stateAtSceneStart == StateAtSceneStart.inactive)
        {
            DisableTargetsImmediately();
        }
    }

    public void DisableTargetsImmediately()
    {
        for (int i = 0; i < targetRenderersDescending.Count; i++)
        {
            targetRenderersDescending.ElementAt(i).enabled = false;
        }
    }

    public void EnableTargetsImmediate()
    {
        for (int i = 0; i < targetRenderersAscending.Count; i++)
        {
            targetRenderersAscending.ElementAt(i).enabled = true;
        }
    }

    public void IntervalEnableTargets()
    {
        StopCoroutine("DeactivateTargetsCoroutine");
        StartCoroutine("ActivateTargetsCoroutine");
        print("Interval Activate");
    }

    public void IntervalDeactivateTargets()
    {
        StopCoroutine("ActivateTargetsCoroutine");
        StartCoroutine("DeactivateTargetsCoroutine");
        print("Interval Deactivate");
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











