using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseContents;
    public GameObject loading;
    public Slider sensitivitySlider;
    private bool isPaused = false;
    private bool isLoading = false;
    // Our access of player here is a hack but whatever.
    private FirstPersonController player;
    private float baseSensitivity;
    public GameObject mainPage;
    public GameObject settingsPage;

    void Start() {
        GameObject playerObject = GameObject.Find("FPSController");
        if(!playerObject) {
            throw new System.Exception("failed to find player!");
        }

        player = playerObject.GetComponent<FirstPersonController>();
        baseSensitivity = player.m_MouseLook.XSensitivity;
        sensitivitySlider.onValueChanged.AddListener (delegate {UpdateMouseSensitivity();});
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

    public void Settings() {
        mainPage.SetActive(false);
        settingsPage.SetActive(true);
    }

    public void Back() {
        mainPage.SetActive(true);
        settingsPage.SetActive(false);
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

    private void UpdateMouseSensitivity() {
        player.m_MouseLook.XSensitivity = sensitivitySlider.value;
        player.m_MouseLook.YSensitivity = sensitivitySlider.value;
    }
}
