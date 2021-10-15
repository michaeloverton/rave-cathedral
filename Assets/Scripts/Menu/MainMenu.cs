using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsMenu;
    public GameObject skipMenu;
    public GameObject buttons;
    public TrackSkipper trackSkipper;
    public GameObject loadingText;
    public SceneChanger sceneChanger;

    public void Play() {
        // "Skip" to the first track.
        trackSkipper.SetTrackSkip(1);
        buttons.SetActive(false);
        loadingText.SetActive(true);

        StartCoroutine(sceneChanger.AsyncLoad());
    }

    public void Instructions() {
        this.gameObject.SetActive(false);
        instructionsMenu.SetActive(true);
    }

    public void Skip() {
        this.gameObject.SetActive(false);
        skipMenu.SetActive(true);
    }

    public void Quit() {
        #if UNITY_EDITOR 
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #endif

        Application.Quit();
    }
}
