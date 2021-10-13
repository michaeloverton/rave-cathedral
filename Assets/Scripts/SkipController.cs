using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipController : MonoBehaviour
{
    public Transform trackOneStart;
    public Transform trackTwoStart;
    public Transform trackThreeStart;
    public GameObject player;

    void Start()
    {
        TrackSkipper skipper = GameObject.Find("TrackSkipper").GetComponent<TrackSkipper>();
        int track = skipper.GetTrackSkip();
        if(track > 0) {
            if(track == 1) {
                Instantiate(player, trackOneStart.position, Quaternion.AngleAxis(90, Vector3.up));
            } else if(track == 2) {
                Instantiate(player, trackTwoStart.position, Quaternion.AngleAxis(90, Vector3.up));
            } else {
                Instantiate(player, trackThreeStart.position, Quaternion.AngleAxis(90, Vector3.up));
            }
        }
    }
}
