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

    void Start()
    {
        int track;
        if(!developmentMode) {
            TrackSkipper skipper = GameObject.Find("TrackSkipper").GetComponent<TrackSkipper>();
            track = skipper.GetTrackSkip();
        } else {
            track = 3;
        }
        
        if(track == 1) {
            if(!developmentMode) Instantiate(player, trackOneStart.position, Quaternion.AngleAxis(90, Vector3.up));
            startTrack = trackOneMusic;
            trackOneTitleTrigger.MakeFirstTrack();
        } else if(track == 2) {
            if(!developmentMode) Instantiate(player, trackTwoStart.position, Quaternion.AngleAxis(90, Vector3.up));
            startTrack = trackTwoMusic;
            trackTwoTitleTrigger.MakeFirstTrack();
        } else {
            if(!developmentMode) Instantiate(player, trackThreeStart.position, Quaternion.AngleAxis(90, Vector3.up));
            startTrack = trackThreeMusic;
            trackThreeTitleTrigger.MakeFirstTrack();
        }
    }

    void Update() {
        // Fade in the music.
        startTrack.volume += fadeInSpeed * Time.deltaTime;
    }
}
