using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSkipper : MonoBehaviour
{
    // If track > 0, main scene will skip to track.
    private int track = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetTrackSkip(int skipTo) {
        track = skipTo;
    }

    public int GetTrackSkip() {
        return track;
    }
}
