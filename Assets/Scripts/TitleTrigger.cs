using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleTrigger : MonoBehaviour
{
    public TextMeshProUGUI trackNumberText;
    public TextMeshProUGUI trackTitleText;
    public string trackNumber;
    public string trackTitle;
    private bool displayed = false;
    private bool isFirstTrack = false;

    void OnTriggerEnter(Collider other) {
        if(!displayed) {
            trackNumberText.text = trackNumber;
            trackTitleText.text = trackTitle;
            displayed = true;
            StartCoroutine(displayTitle());
        }
    }

    IEnumerator displayTitle() 
    {
        // Wait an additional time for first track to let screen fade in.
        if(isFirstTrack) {
            yield return new WaitForSeconds(3);
        }

        yield return new WaitForSeconds(1);
        trackNumberText.enabled = true;

        yield return new WaitForSeconds(2);
        trackTitleText.enabled = true;

        yield return new WaitForSeconds(4);
        trackNumberText.enabled = false;
        trackTitleText.enabled = false;
    }

    public void MakeFirstTrack() {
        isFirstTrack = true;
    }
}
