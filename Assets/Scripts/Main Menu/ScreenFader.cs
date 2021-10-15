using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public RawImage background;
    public float fadeSpeed = 3f;
    private bool fadeScreen = false;
    private bool fadeComplete = false;

    // Update is called once per frame
    void Update()
    {
        if(fadeScreen && background.color.a < 1) {
            Color color = background.color;
            color.a += fadeSpeed * Time.deltaTime;
            background.color = color;
        }

        if(background.color.a >= 1) {
            fadeComplete = true;
        }
    }

    public void FadeScreen() {
        fadeScreen = true;
    }

    public bool FadeComplete() {
        return fadeComplete;
    }
}
