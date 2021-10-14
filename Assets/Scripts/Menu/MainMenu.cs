using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject instructionsMenu;
    public GameObject skipMenu;

    public void Play() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
