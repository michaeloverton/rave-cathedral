using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MovementToggler : MonoBehaviour
{
    public FirstPersonController player;
    public bool turnOn;

    void OnTriggerEnter(Collider other) {
        if(turnOn) {
            player.SetCanMove(true);
        } else {
            player.SetCanMove(false);
        }
    }
}
