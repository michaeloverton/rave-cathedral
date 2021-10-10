using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject player;
    public float trackOneChangeStartY;
    public float trackOneChangeEndY;
    public AudioSource trackOne;
    private float trackOneStartVolume;
    private float trackOneStartFilter;
    public AudioLowPassFilter trackOneFilter;

    void Start() {
        trackOneStartVolume = trackOne.volume;
        trackOneStartFilter = trackOneFilter.cutoffFrequency;
    }

    // Update is called once per frame
    void Update()
    {
        float playerYPos = player.transform.position.y;
        if(playerYPos > trackOneChangeStartY) {
            // If we're outside transition range, disable filter.
            if(trackOneFilter.enabled) {
                trackOneFilter.enabled = false;
            }
        }

        if(playerYPos <= trackOneChangeStartY && playerYPos >= trackOneChangeEndY) {
            // The filter is off by default because we don't want unnecessary distortion.
            if(!trackOneFilter.enabled) {
                trackOneFilter.enabled = true;
            }
            float fadePercent = 1 - Mathf.Pow(
                ((playerYPos - trackOneChangeStartY) / (trackOneChangeEndY - trackOneChangeStartY)), 2
            );
            trackOne.volume = trackOneStartVolume * fadePercent;
            trackOneFilter.cutoffFrequency = trackOneStartFilter * fadePercent;
        }
    }
}
