using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class IntervalRendererActivator : MonoBehaviour
{
    [Header("Add Renderers:")]
    public bool fromChildren = true;
    public GameObject fromChildrenOf;
    public bool byTag = false;
    public string targetTag;

    [Header("Scene Start Settings")]
    public StateAtSceneStart stateAtSceneStart;
    public enum StateAtSceneStart { intervalActivate, intervalActivateDelayed, active, activeDelayed, inactive };
    public float delayTimeInSeconds = 0f;

    [Header("Activate Settings")]
    public float activateTransitionTime = 5f;
    public enum ActivateTimeMode { transitionTime, intervalTime };
    public ActivateTimeMode activateTimeMode;
    public float activateIntervalTime = .01f;
    public int activationsPerInterval = 1;
    public float finalActivateInterval;
    //public int activationsPerInterval = 3;

    [Header("Deactivate Settings")]
    public float deactivateTransitionTime = 5f;
    public enum DeactivateTimeMode { transitionTime, intervalTime };
    public DeactivateTimeMode deactivateTimeMode;
    public float deactivateIntervalTime = .01f;
    public int deactivationsPerInterval = 1;
    public float finalDeactivateInterval;
    //public int deactivationsPerInterval = 3;

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


        if (activateTimeMode == ActivateTimeMode.transitionTime)
        {
            finalActivateInterval = activateTransitionTime / targetRenderersDescending.Count;
        }
        else
        {
            finalActivateInterval = activateIntervalTime;
        }

        if (deactivateTimeMode == DeactivateTimeMode.intervalTime)
        {
            finalDeactivateInterval = deactivateTransitionTime / targetRenderersDescending.Count;
        }
        else
        {
            finalDeactivateInterval = deactivateIntervalTime;
        }
        
        if (stateAtSceneStart == StateAtSceneStart.intervalActivate)
        {
            DeactivateTargetsImmediate();
            IntervalActivateTargets();
        }
        else if (stateAtSceneStart == StateAtSceneStart.intervalActivateDelayed)
        {
            DeactivateTargetsImmediate();
            Invoke("IntervalActivateTargets", delayTimeInSeconds);
        }
        else if (stateAtSceneStart == StateAtSceneStart.active)
        {
            ActivateTargetsImmediate();
        }
        else if (stateAtSceneStart == StateAtSceneStart.activeDelayed)
        {
            DeactivateTargetsImmediate();
            Invoke("ActivateTargetsImmediate", delayTimeInSeconds);
        }
        else if (stateAtSceneStart == StateAtSceneStart.inactive)
        {
            DeactivateTargetsImmediate();
        }
    }

    public void DeactivateTargetsImmediate()
    {
        for (int i = 0; i < targetRenderersDescending.Count; i++)
        {
            targetRenderersDescending.ElementAt(i).enabled = false;
        }
    }

    public void ActivateTargetsImmediate()
    {
        for (int i = 0; i < targetRenderersAscending.Count; i++)
        {
            targetRenderersAscending.ElementAt(i).enabled = true;
        }
    }

    public void IntervalActivateTargets()
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
        for (int i = 0; i < targetRenderersDescending.Count; i += activationsPerInterval)
        {
            for (int e = 0; e <= activationsPerInterval && i+e < targetRenderersDescending.Count; e++)
            {
                
                targetRenderersDescending.ElementAt(i+e).enabled = true;
            }

            yield return new WaitForSeconds(finalActivateInterval);
        }
    }


    IEnumerator DeactivateTargetsCoroutine()
    {
        for (int i = 0; i < targetRenderersAscending.Count; i += deactivationsPerInterval)
        {
            for (int e = 0; e <= deactivationsPerInterval; e++)

            {
                targetRenderersAscending.ElementAt(i+e).enabled = false;
            }

            yield return new WaitForSeconds(finalDeactivateInterval);
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











