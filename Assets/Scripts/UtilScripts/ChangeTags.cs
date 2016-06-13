using UnityEngine;
using System.Collections;

public class ChangeTags : MonoBehaviour
{

    private GameObject[] sceneObjects;
    private GameObject[] shelfParts;

    // Use this for initialization
    void Start()
    {
        sceneObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject go in sceneObjects)
            if (go.name.StartsWith("ShelfMin"))
        {
                    go.transform.tag = "ShelfPart";
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}