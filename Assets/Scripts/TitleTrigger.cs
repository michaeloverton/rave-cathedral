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
        yield return new WaitForSeconds(1);
        trackNumberText.enabled = true;

        yield return new WaitForSeconds(2);
        trackTitleText.enabled = true;

        yield return new WaitForSeconds(4);
        trackNumberText.enabled = false;
        trackTitleText.enabled = false;
    }
}
