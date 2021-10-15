using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public RawImage background;
    public MusicFader musicFader;
    public ScreenFader screenFader;

    public IEnumerator AsyncLoad()
    {
        background.enabled = true;

        yield return null;
        
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Prototype");
        asyncLoad.allowSceneActivation = false;

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            if(asyncLoad.progress >= 0.9f) {
                musicFader.FadeMusic();
                screenFader.FadeScreen();

                yield return null;

                if(musicFader.FadeComplete() && screenFader.FadeComplete()) {
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
