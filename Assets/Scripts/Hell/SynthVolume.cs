using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynthVolume : MonoBehaviour
{
    private AudioSource synth;
    private float maxVolume;
    private float rootYValue;
    private bool modulateVolume = false;
    public GameObject player;
    public float modulationDistance = 250f;

    // Start is called before the first frame update
    void Start()
    {
        synth = GetComponent<AudioSource>();
        maxVolume = synth.volume;
        rootYValue = transform.position.y;
        synth.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(modulateVolume) {
            float modPercent = 1 - (Mathf.Abs(player.transform.position.y - rootYValue) / modulationDistance);
            synth.volume = maxVolume * modPercent;
        }
    }

    void OnTriggerEnter(Collider other) {
        modulateVolume = true;
    }

    void OnTriggerExit(Collider other) {
        modulateVolume = false;
    }
}
