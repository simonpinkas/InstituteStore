using UnityEngine;
using System.Collections;

using RenderHeads.Media.AVProVideo;

public class MediaController : MonoBehaviour {

    public MediaPlayer mp;
    

    // Use this for initialization
    void Start () {

       mp.Events.AddListener(OnMediaPlayerEvent);
        //mp.OpenVideoFromFile(mp.m_VideoLocation, mp.m_VideoPath);
        mp.Control.Pause();

    }


    public void OnMediaPlayerEvent(MediaPlayer mp, MediaPlayerEvent.EventType et)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
               // mp.Control.Play();
                break;
            case MediaPlayerEvent.EventType.FirstFrameReady:
                print("First Frame Is Ready");
                break;
            case MediaPlayerEvent.EventType.Started:
                print("Playback Started");
                break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                print("Finished Playing");
                break;
        }
    }


	// Update is called once per frame
	void Update () {
	


	}
}
