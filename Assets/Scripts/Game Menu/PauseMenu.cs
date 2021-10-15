using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseContents;
    public GameObject loading;
    private bool isPaused = false;
    private bool isLoading = false;
    // Our access of player here is a hack but whatever.
    private FirstPersonController player;

    void Start() {
        GameObject playerObject = GameObject.Find("FPSController");
        if(!playerObject) {
            throw new System.Exception("failed to find player!");
        }

        player = playerObject.GetComponent<FirstPersonController>();
    }

    void Update() {
        if(!isLoading) {
            if(Input.GetKeyUp(KeyCode.Escape)){
                isPaused = !isPaused;

                if(isPaused) {
                    pauseContents.SetActive(true);
                    player.SetPaused(true);
                } else {
                    pauseContents.SetActive(false);
                    player.SetPaused(false);
                }
            }
        }
    }

    public void Continue() {
        isPaused = false;
        pauseContents.SetActive(false);

        player.SetPaused(false);
    }

    public void TitleScreen() {
        pauseContents.SetActive(false);
        loading.SetActive(true);
        isLoading = true;

        // TODO: Make smooth fade out. This is very harsh.
        StartCoroutine(AsyncLoad());
    }

    public void Quit() {
        #if UNITY_EDITOR 
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        #endif

        Application.Quit();
    }

    IEnumerator AsyncLoad()
    {
        yield return null;
        
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
