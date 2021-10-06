using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightActivator : MonoBehaviour
{
    public GameObject lightContainer;

    private void OnTriggerEnter(Collider other) {
        lightContainer.SetActive(true);
    }

    void OnTriggerExit(Collider other) {
        lightContainer.SetActive(false);
    }
}
