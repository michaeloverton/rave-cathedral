using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovZoom : MonoBehaviour
{
    public Camera playerCamera;
    private bool zoom = false;
    public int zoomExponent = 1;
    public float zoomSpeed = 5f;
    private float distance;
    private float minFov;
    public float maxFov;
    // Prevent unnecessary FOV modification.
    private bool atMinFov = true;

    void Start() {
        minFov = playerCamera.fieldOfView;
    }

    void OnTriggerEnter(Collider other) {
        zoom = true;
    }

    void OnTriggerExit(Collider other) {
        zoom = false;
    }

    void OnTriggerStay(Collider other) {
        Debug.Log("staying in triggger");
        distance = Vector3.Magnitude(transform.position - other.transform.position);
    }

    void Update()
    {
        if(zoom) {
            if(playerCamera.fieldOfView < maxFov) {
                playerCamera.fieldOfView += (1/Mathf.Pow(distance, zoomExponent)) * zoomSpeed * Time.deltaTime;
            }
            atMinFov = false;

        } else {
            if(!atMinFov) {
                if(playerCamera.fieldOfView > minFov) {
                    playerCamera.fieldOfView -= (1/Mathf.Pow(distance, zoomExponent)) * zoomSpeed * Time.deltaTime;
                } else {
                    atMinFov = true;
                }
            }
        }
    }
}
