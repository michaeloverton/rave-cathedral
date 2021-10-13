using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovZoom : MonoBehaviour
{
    public Camera playerCamera;
    public int zoomExponent = 1;
    public float zoomSpeed = 5f;
    private float distance;
    private float minFov;
    public float maxFov;
    // Prevent unnecessary FOV modification.
    private float colliderRadius;

    void Start() {
        minFov = playerCamera.fieldOfView;
        colliderRadius = GetComponent<SphereCollider>().radius;
    }

    // void OnTriggerEnter(Collider other) {
    //     zoom = true;
    // }

    void OnTriggerExit(Collider other) {
        playerCamera.fieldOfView = minFov;
    }

    void OnTriggerStay(Collider other) {
        distance = Vector3.Magnitude(transform.position - other.transform.position);
        if(distance > colliderRadius) {
            return;
        }
        
        float fovDiff = maxFov - minFov;
        float modPercent = 1 - Mathf.Pow((distance / colliderRadius), 2);
        float modAmount = fovDiff * modPercent;
        playerCamera.fieldOfView = minFov + modAmount;
    }

    // void Update()
    // {
    //     if(zoom) {
    //         if(playerCamera.fieldOfView < maxFov) {
    //             playerCamera.fieldOfView += (1/Mathf.Pow(distance, zoomExponent)) * zoomSpeed * Time.deltaTime;
    //         }
    //         atMinFov = false;

    //     } else {
    //         if(!atMinFov) {
    //             if(playerCamera.fieldOfView > minFov) {
    //                 playerCamera.fieldOfView -= (1/Mathf.Pow(distance, zoomExponent)) * zoomSpeed * Time.deltaTime;
    //             } else {
    //                 atMinFov = true;
    //             }
    //         }
    //     }
    // }
}
