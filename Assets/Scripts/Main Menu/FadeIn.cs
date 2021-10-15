using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public RawImage background;
    public float fadeSpeed = 0.75f;
    private bool shouldFadeIn = true;

    // Update is called once per frame
    void Update()
    {
        if(background.color.a > 0 && shouldFadeIn) {
            Color color = background.color;
            color.a -= fadeSpeed * Time.deltaTime;
            background.color = color;

            // If after modification, we are done, disable the black screen.
            if(background.color.a <= 0) {
                background.enabled = false;
                shouldFadeIn = false;
            }
        }
    }
}
