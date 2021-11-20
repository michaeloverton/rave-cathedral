using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTwoFilterController : MonoBehaviour
{
    public GameObject player;
    public SkipController skipController;

    // Track 2
    public float trackTwoFilterSweepStartY;
    public float trackTwoFilterSweepEndY;
    private float trackTwoStartFilter;
    public float trackTwoFilterMin = 1000f;
    public AudioLowPassFilter trackTwoFilter;
    public AudioLowPassFilter bassOneFilter;
    public AudioLowPassFilter bassTwoFilter;
    private float cutoffDistance;
    
    void Start() {
        trackTwoStartFilter = trackTwoFilter.cutoffFrequency;
        cutoffDistance = trackTwoFilter.cutoffFrequency - trackTwoFilterMin;
    }

    // Update is called once per frame
    void Update()
    {
        float playerYPos = player.transform.position.y;

        // Filter cutoff lowers as we travel downwards.
        if(playerYPos <= trackTwoFilterSweepStartY && playerYPos >= trackTwoFilterSweepEndY) {
            float modPercent = Mathf.Pow(
                ((playerYPos - trackTwoFilterSweepEndY) / (trackTwoFilterSweepStartY - trackTwoFilterSweepEndY)), 2
            );

            float frequencyAboveMin = cutoffDistance * modPercent;

            trackTwoFilter.cutoffFrequency = trackTwoFilterMin + frequencyAboveMin;
            bassOneFilter.cutoffFrequency = trackTwoFilterMin + frequencyAboveMin;
            bassTwoFilter.cutoffFrequency = trackTwoFilterMin + frequencyAboveMin;
        }
    }
}
