using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelLightActivator : MonoBehaviour
{
    private float maxIntensity;
    private Light activatedLight;
    public float speed = 30f;
    private bool activate = false;

    // Start is called before the first frame update
    void Start()
    {
        activatedLight = GetComponent<Light>();
        maxIntensity = activatedLight.intensity;
        // After storing the intensity set in scene, set it to 0.
        activatedLight.intensity = 0;
    }

    private void OnTriggerEnter(Collider other) {
        activatedLight.enabled = true;
        activate = true;
    }

    private void OnTriggerExit(Collider other) {
        activate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activate) {
            if(activatedLight.intensity < maxIntensity) {
                activatedLight.intensity += speed * Time.deltaTime;
            }
        } else {
            if(activatedLight.intensity > 0) {
                activatedLight.intensity -= speed * Time.deltaTime;
            } else if(activatedLight.enabled) {
                // Turn off the light once it's below 0.
                activatedLight.enabled = false;
            }
        }
    }
}
