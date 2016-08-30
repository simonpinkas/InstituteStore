using UnityEngine;
using System.Collections;

public class OriginalMaterial : MonoBehaviour {
	public Material originalMaterial;

    public void SetToOriginalMaterial() {
        gameObject.GetComponent<Renderer>().material = originalMaterial;

        //for (int i = 0; i < gameObject.GetComponent<Renderer>().materials.Length; i++) {
        //    Debug.Log(i);
        //    gameObject.GetComponent<Renderer>(). materials[i] = originalMaterial;
        //}
    }
}
