using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFader : MonoBehaviour
{
    private bool fade = false;
    public AudioSource music;
    public float fadeSpeed = 2f;
    private bool fadeComplete = false;

    // Update is called once per frame
    void Update()
    {
        if(fade && music.volume > 0) {
            music.volume -= fadeSpeed * Time.deltaTime;
        }

        if(music.volume <= 0) {
            fadeComplete = true;
        }
    }

    public void FadeMusic() {
        fade = true;
    }

    public bool FadeComplete() {
        return fadeComplete;
    }
}
