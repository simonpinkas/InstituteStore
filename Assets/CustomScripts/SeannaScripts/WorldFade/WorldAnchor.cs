using UnityEngine;
using System.Collections;

public class WorldAnchor : MonoBehaviour {

    private Material originalSkybox;
    public Material sceneSkybox;
	public GameObject fadeOutWorld;
	public GameObject fadeInWorld;
	public float secondsToFade;
	public float fadeOutFogDensity;
	public Color fadeOutFogColor;
	public float fadeInFogDensity;
	public Color fadeInFogColor;

	private bool readyToSwitch = true;
	private float secondsSinceSwitch = 0;

	private WorldFade worldFade;

	// Use this for initialization
	void Start () {
        originalSkybox = RenderSettings.skybox;
		worldFade = GameObject.Find("WorldFade").GetComponent<WorldFade>();
	}

	void Update() {
		secondsSinceSwitch += Time.deltaTime;
		if (secondsSinceSwitch >= secondsToFade) {
			readyToSwitch = true;
		}
	}
	
	public void Switch() {
		if (readyToSwitch) {
			worldFade.Fade(fadeOutWorld, fadeInWorld, secondsToFade, fadeOutFogDensity, fadeOutFogColor, fadeInFogDensity, fadeInFogColor, sceneSkybox, originalSkybox);
	
			GameObject temp = fadeInWorld;
			fadeInWorld = fadeOutWorld;
			fadeOutWorld = temp;

			float densityTemp = fadeInFogDensity;
			fadeInFogDensity = fadeOutFogDensity;
			fadeOutFogDensity = densityTemp;

			Color colorTemp = fadeInFogColor;
			fadeInFogColor = fadeOutFogColor;
			fadeOutFogColor = colorTemp;

            Material matTemp = originalSkybox;
            originalSkybox = sceneSkybox;
            sceneSkybox = matTemp;

			readyToSwitch = false;
			secondsSinceSwitch = 0;
		}
	}

	
}
