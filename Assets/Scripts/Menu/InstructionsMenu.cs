using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void Back() {
        this.gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
