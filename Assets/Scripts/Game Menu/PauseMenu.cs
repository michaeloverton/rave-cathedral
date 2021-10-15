using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public GameObject contents;
    private bool isPaused = false;

    // This is a hack. The pause menu can freeze the player.
    private FirstPersonController player;

    void Start() {
        GameObject playerObject = GameObject.Find("FPSController");
        if(!playerObject) {
            throw new System.Exception("failed to find player!");
        }

        player = playerObject.GetComponent<FirstPersonController>();
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.Escape)){
            isPaused = !isPaused;

            if(isPaused) {
                contents.SetActive(true);
            } else {
                contents.SetActive(false);
            }
        }
    }

    public void Continue() {
        isPaused = false;
        contents.SetActive(false);
    }

    public void TitleScreen() {
        return;
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
