using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public TrackSkipper trackSkipper;
    public GameObject buttons;
    public GameObject loadingText;
    public SceneChanger sceneChanger;

    public void SetTrackSkip(int skip) {
        trackSkipper.SetTrackSkip(skip);
        buttons.SetActive(false);
        loadingText.SetActive(true);

        StartCoroutine(sceneChanger.AsyncLoad());
    }

    public void Back() {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
