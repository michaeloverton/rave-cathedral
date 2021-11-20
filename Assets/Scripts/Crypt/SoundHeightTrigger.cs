using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHeightTrigger : MonoBehaviour
{
    AudioSource sound;
    private float maxVolume;
    BoxCollider triggerCollider;
    private float colliderHalfHeight;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        maxVolume = sound.volume;
        triggerCollider = GetComponent<BoxCollider>();
        colliderHalfHeight = triggerCollider.size.y / 2;

        // Set volume to 0 after storing max volume.
        sound.volume = 0;
    }

    void OnTriggerStay(Collider other) {
        float distance = Mathf.Abs(other.transform.position.y - transform.position.y);
        float modPercent = 1 - (distance / colliderHalfHeight);
        sound.volume = modPercent * maxVolume;
    }

    void OnTriggerExit(Collider other) {
        // Ensure volume is 0 upon exiting.
        sound.volume = 0;
    }
}
