using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCanceller : MonoBehaviour
{
    public MusicController musicController;

    void OnTriggerEnter(Collider other) {
        musicController.CanTransition(false);
    }

    void OnTriggerExit(Collider other) {
        musicController.CanTransition(true);
    }
}
