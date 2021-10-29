using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject player;
    public SkipController skipController;

    // Track 1
    public float trackOneChangeStartY;
    public float trackOneChangeEndY;
    public AudioSource trackOne;
    private float trackOneStartVolume;
    private float trackOneStartFilter;
    public AudioLowPassFilter trackOneFilter;

    // Track 2
    public float trackTwoFadeInStartY;
    public float trackTwoFadeInEndY;
    public float trackTwoFadeOutStartY;
    public float trackTwoFadeOutEndY;
    public AudioSource trackTwo;
    private float trackTwoStartVolume;
    private float trackTwoStartFilter;
    public AudioLowPassFilter trackTwoFilter;

    // Track 2
    public float trackThreeFadeInStartY;
    public float trackThreeFadeInEndY;
    public float trackThreeFadeOutStartY;
    public float trackThreeFadeOutEndY;
    public AudioSource trackThree;
    private float trackThreeStartVolume;
    private float trackThreeStartFilter;
    public AudioLowPassFilter trackThreeFilter;

    void Start() {
        trackOneStartVolume = skipController.TrackOneMaxVolume();
        trackOneStartFilter = trackOneFilter.cutoffFrequency;

        trackTwoStartVolume = skipController.TrackTwoMaxVolume();
        trackTwoStartFilter = trackTwoFilter.cutoffFrequency;

        trackThreeStartVolume = skipController.TrackThreeMaxVolume();
        trackThreeStartFilter = trackThreeFilter.cutoffFrequency;

        Debug.Log("trak one start: " + trackOneStartVolume);
        Debug.Log("trak two start: " + trackTwoStartVolume);
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

        // Fade out track 1
        if(playerYPos <= trackOneChangeStartY && playerYPos >= trackOneChangeEndY) {
            // The filter is off by default because we don't want unnecessary distortion.
            if(!trackOneFilter.enabled) {
                trackOneFilter.enabled = true;
            }
            float fadePercent = 1 - Mathf.Pow(
                ((playerYPos - trackOneChangeStartY) / (trackOneChangeEndY - trackOneChangeStartY)), 2
            );
            trackOne.volume = trackOneStartVolume * fadePercent;
            // trackOneFilter.cutoffFrequency = trackOneStartFilter * fadePercent;
        }

        // Fade in track 2
        if(playerYPos <= trackTwoFadeInStartY && playerYPos >= trackTwoFadeInEndY) {

            float fadePercent = Mathf.Pow(
                ((playerYPos - trackTwoFadeInStartY) / (trackTwoFadeInEndY - trackTwoFadeInStartY)), 2
            );
            trackTwo.volume = trackTwoStartVolume * fadePercent;
        }

        // Fade out track 2
        if(playerYPos <= trackTwoFadeOutStartY && playerYPos >= trackTwoFadeOutEndY) {
            // The filter is off by default because we don't want unnecessary distortion.
            // if(!trackOneFilter.enabled) {
            //     trackOneFilter.enabled = true;
            // }
            float fadePercent = 1 - Mathf.Pow(
                ((playerYPos - trackTwoFadeOutStartY) / (trackTwoFadeOutEndY - trackTwoFadeOutStartY)), 2
            );
            trackTwo.volume = trackTwoStartVolume * fadePercent;
            // trackOneFilter.cutoffFrequency = trackOneStartFilter * fadePercent;
        }

        // Fade in track 3
        if(playerYPos <= trackThreeFadeInStartY && playerYPos >= trackThreeFadeInEndY) {

            float fadePercent = Mathf.Pow(
                ((playerYPos - trackThreeFadeInStartY) / (trackThreeFadeInEndY - trackThreeFadeInStartY)), 2
            );
            trackThree.volume = trackThreeStartVolume * fadePercent;
        }
    }
}
