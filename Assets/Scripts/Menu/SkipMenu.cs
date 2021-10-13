using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public TrackSkipper trackSkipper;

    public void SetTrackSkip(int skip) {
        trackSkipper.SetTrackSkip(skip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back() {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
