using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipController : MonoBehaviour
{
    public Transform trackOneStart;
    public AudioSource trackOneMusic;
    public TitleTrigger trackOneTitleTrigger;
    public Transform trackTwoStart;
    public AudioSource trackTwoMusic;
    public TitleTrigger trackTwoTitleTrigger;
    public Transform trackThreeStart;
    public AudioSource trackThreeMusic;
    public TitleTrigger trackThreeTitleTrigger;
    public GameObject player;
    public bool developmentMode; // Ignores track skipping.
    private AudioSource startTrack;
    public float fadeInSpeed = 0.25f;
    private bool fadeInComplete = false;
    private float trackOneMaxVolume;
    private float trackTwoMaxVolume;
    private float trackThreeMaxVolume;
    private float startTrackMaxVolume;

    void Start()
    {
        // Remember the "max" volumes of each music when it's on.
        trackOneMaxVolume = trackOneMusic.volume;
        trackTwoMaxVolume = trackTwoMusic.volume;
        trackThreeMaxVolume = trackThreeMusic.volume;

        // Start all volumes at 0.
        trackOneMusic.volume = 0;
        trackTwoMusic.volume = 0;
        trackThreeMusic.volume = 0;

        int track;
        if(!developmentMode) {
            TrackSkipper skipper = GameObject.Find("TrackSkipper").GetComponent<TrackSkipper>();
            track = skipper.GetTrackSkip();
        } else {
            track = 2;
        }
        
        if(track == 1) {
            if(!developmentMode) Instantiate(player, trackOneStart.position, Quaternion.AngleAxis(90, Vector3.up));
            startTrack = trackOneMusic;
            startTrackMaxVolume = trackOneMaxVolume;
            
            trackOneTitleTrigger.MakeFirstTrack();
        } else if(track == 2) {
            if(!developmentMode) Instantiate(player, trackTwoStart.position, Quaternion.AngleAxis(90, Vector3.up));
            startTrack = trackTwoMusic;
            startTrackMaxVolume = trackTwoMaxVolume;
            
            trackTwoTitleTrigger.MakeFirstTrack();
        } else {
            if(!developmentMode) Instantiate(player, trackThreeStart.position, Quaternion.AngleAxis(90, Vector3.up));
            startTrack = trackThreeMusic;
            startTrackMaxVolume = trackThreeMaxVolume;
            
            trackThreeTitleTrigger.MakeFirstTrack();
        }
    }

    void Update() {
        // Fade in the music.
        if(!fadeInComplete && startTrack.volume < startTrackMaxVolume) {
            startTrack.volume += fadeInSpeed * Time.deltaTime;
        } else {
            if(!fadeInComplete) fadeInComplete = true;
        }
    }

    public float TrackOneMaxVolume() {
        return trackOneMaxVolume;
    }

    public float TrackTwoMaxVolume() {
        return trackTwoMaxVolume;
    }

    public float TrackThreeMaxVolume() {
        return trackThreeMaxVolume;
    }
}
