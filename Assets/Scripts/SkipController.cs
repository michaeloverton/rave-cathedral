using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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
    public int developmentModeStartTrack = 1;
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

        // Track one is always the first track because of the removal of track skipping.
        if(!developmentMode) {
            startTrack = trackOneMusic;
            startTrackMaxVolume = trackOneMaxVolume;
            trackOneTitleTrigger.MakeFirstTrack();
        } else {
            if(developmentModeStartTrack == 1) {
                startTrack = trackOneMusic;
                startTrackMaxVolume = trackOneMaxVolume;
                trackOneTitleTrigger.MakeFirstTrack();
            } else if(developmentModeStartTrack ==2) {
                startTrack = trackTwoMusic;
                startTrackMaxVolume = trackTwoMaxVolume;
                trackTwoTitleTrigger.MakeFirstTrack();
            } else {
                startTrack = trackThreeMusic;
                startTrackMaxVolume = trackThreeMaxVolume;
                trackThreeTitleTrigger.MakeFirstTrack();
            }
        }
        

        // int track;
        // if(!developmentMode) {
        //     TrackSkipper skipper = GameObject.Find("TrackSkipper").GetComponent<TrackSkipper>();
        //     track = skipper.GetTrackSkip();
        // } else {
        //     track = developmentModeStartTrack;
        // }
        
        // if(track == 1) {
        //     player.transform.position = trackOneStart.position;
        //     startTrack = trackOneMusic;
        //     startTrackMaxVolume = trackOneMaxVolume;
            
        //     trackOneTitleTrigger.MakeFirstTrack();
        // } else if(track == 2) {
        //     player.transform.position = trackTwoStart.position;
        //     startTrack = trackTwoMusic;
        //     startTrackMaxVolume = trackTwoMaxVolume;
            
        //     trackTwoTitleTrigger.MakeFirstTrack();
        // } else {
        //     player.transform.position = trackThreeStart.position;
        //     startTrack = trackThreeMusic;
        //     startTrackMaxVolume = trackThreeMaxVolume;
            
        //     trackThreeTitleTrigger.MakeFirstTrack();
        // }
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
