using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLight : MonoBehaviour
{
    private Light orbLight;
    private float maxIntensity;
    private SphereCollider sphereCollider;
    public float remappedMin = -1f;
    public float remappedMax = 1f;

    // Start is called before the first frame update
    void Start()
    {
        orbLight = GetComponent<Light>();
        maxIntensity = orbLight.intensity;
        sphereCollider = GetComponent<SphereCollider>();
    }

    // void OnTriggerEnter() {
    //     fading = true;
    // }

    void OnTriggerStay(Collider other) {
        float distance = Vector3.Distance(transform.position, other.transform.position);
        if(distance > sphereCollider.radius) {
            return;
        }

        float modPercent = remap(distance, 0, sphereCollider.radius, remappedMin, remappedMax);
        Debug.Log(modPercent);
        orbLight.intensity = maxIntensity * modPercent;
    }

    void OnTriggerExit(Collider other) {
        orbLight.intensity = maxIntensity;
    }

    private float remap (float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
    
}
