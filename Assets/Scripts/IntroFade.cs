using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroFade : MonoBehaviour
{
    public RawImage background;
    public float fadeSpeed = 0.05f;
    public float pureBlackTime = 1f;
    private bool fadeFinished = false;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if(!fadeFinished) {
            if(timer > pureBlackTime) {
                if(background.color.a > 0) {
                    Color color = background.color;
                    color.a -= fadeSpeed * Time.deltaTime;
                    background.color = color;
                } else {
                    // Disable the black background when fully faded.
                    background.enabled = false;
                    fadeFinished = true;
                }
            }
            
            timer += Time.deltaTime;
        }
    }

    public bool IsFadeFinished() {
        return fadeFinished;
    }
}
