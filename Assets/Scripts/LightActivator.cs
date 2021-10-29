using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivator : MonoBehaviour
{
    public GameObject lightContainer;
    private Light rightLight;
    private float rightMaxIntensity;
    private Light leftLight;
    private float leftMaxIntensity;
    private bool lightsOn = false;
    public float onSpeed = 2f;

    public void Start() {
        // rightLight = GameObject.Find("Up First Floor Right").GetComponent<Light>();
        Transform lightsContainer = transform.Find("Lights Container");
        rightLight = lightsContainer.Find("Up First Floor Right").GetComponent<Light>();
        rightMaxIntensity = rightLight.intensity;
        leftLight = lightsContainer.Find("Up First Floor Left").GetComponent<Light>();
        leftMaxIntensity = leftLight.intensity;

        // Set light intensity to 0 after storing their max intensity.
        rightLight.intensity = 0;
        leftLight.intensity = 0;
    }

    public void Update() {
        if(lightsOn && rightLight.intensity < rightMaxIntensity) {
            rightLight.intensity += onSpeed * Time.deltaTime;
            leftLight.intensity += onSpeed * Time.deltaTime;
        }

        if(!lightsOn && rightLight.intensity > 0) {
            rightLight.intensity -= onSpeed * Time.deltaTime;
            leftLight.intensity -= onSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other) {
        lightsOn = true;
    }

    void OnTriggerExit(Collider other) {
        lightsOn = false;
    }
}
