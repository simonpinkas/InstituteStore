
using UnityEngine;
using System.Collections;

public class WorldFade : MonoBehaviour
{

    private GameObject fadeOutWorld;
    private GameObject fadeInWorld;
    private float fadeRatio = 0;
    private float secondsToFade;
    private bool fading = false;
    private float fadeOutFogDensity;
    private float fadeInFogDensity;
    private Color fadeOutFogColor;
    private Color fadeInFogColor;
    private Material sceneSkybox;
    private Material originalSkybox;


    // Update is called once per frame
    void Update()
    {
        if (fading)
        {
            if (fadeRatio < 1)
            {
                fadeRatio += Time.deltaTime / secondsToFade;
                fadeRatio = Mathf.Min(fadeRatio, 1);
            }

            FadeOut();
            FadeIn();
            ChangeFog();


            if (fadeRatio == 1)
            {
                fading = false;
                fadeRatio = 0;
            }

        }
    }




    /*
     void SetToFadeMode(Material material) {
         material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
         material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
         material.SetInt("_ZWrite", 0);
         material.DisableKeyword("_ALPHATEST_ON");
         material.EnableKeyword("_ALPHABLEND_ON");
         material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
         material.renderQueue = 3000;
     }
     */


    public void Fade(GameObject newFadeOutWorld, GameObject newFadeInWorld, float newSecondsToFade,
        float newFadeOutFogDensity, Color newFadeOutFogColor, float newFadeInFogDensity, Color newFadeInFogColor, Material newSceneSkybox, Material newOriginalSkybox)
    {
        fadeOutWorld = newFadeOutWorld;
        fadeInWorld = newFadeInWorld;
        secondsToFade = newSecondsToFade;
        fading = true;
        fadeRatio = 0;
        fadeOutFogDensity = newFadeOutFogDensity;
        fadeInFogDensity = newFadeInFogDensity;
        fadeOutFogColor = newFadeOutFogColor;
        fadeInFogColor = newFadeInFogColor;
        sceneSkybox = newSceneSkybox;
        originalSkybox = newOriginalSkybox;

        FadeOut();
        FadeIn();
        ChangeFog();

    }



    void FadeOut()
    {

        foreach (Renderer component in fadeOutWorld.GetComponentsInChildren<Renderer>())
        {
            component.enabled = false;
        }

        foreach (Light component in fadeOutWorld.GetComponentsInChildren<Light>())
        {
            component.enabled = false;
        }

        foreach (Terrain component in fadeOutWorld.GetComponentsInChildren<Terrain>())
        {
            component.enabled = false;
        }


        /*  foreach (Behaviour childCompnent in fadeOutWorld.GetComponentsInChildren<Behaviour>())
          {
              childCompnent.enabled = false;
          }
          */


    }

    void FadeIn()


    {

        foreach (Renderer component in fadeInWorld.GetComponentsInChildren<Renderer>())
        {
            component.enabled = true;
        }

        foreach (Light component in fadeInWorld.GetComponentsInChildren<Light>())
        {
            component.enabled = true;
        }

        foreach (Terrain component in fadeInWorld.GetComponentsInChildren<Terrain>())
        {
            component.enabled = true;
        }

    }


    /*
    foreach (Behaviour childCompnent in fadeInWorld.GetComponentsInChildren<Behaviour>())
    {
        childCompnent.enabled = true;
    }
    */






    void ChangeFog()
    {
        RenderSettings.fogColor = Color.Lerp(fadeOutFogColor, fadeInFogColor, fadeRatio);
        RenderSettings.fogDensity = Mathf.Lerp(fadeOutFogDensity, fadeInFogDensity, fadeRatio);

        Debug.Log(Mathf.Lerp(fadeOutFogDensity, fadeInFogDensity, fadeRatio));

    }

}



    /*
	void SetToOriginalMaterial(Renderer renderer) {
		OriginalMaterial originalMaterial = renderer.gameObject.GetComponent<OriginalMaterial> ();
		if (originalMaterial != null) {
			originalMaterial.SetToOriginalMaterial();
		}
    */
