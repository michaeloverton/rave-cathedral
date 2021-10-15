using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMorpher : MonoBehaviour
{
    private Vector3 originalScale;
    // private Vector3 currentScale;
    public float maxModulationScale = 2;
    public float modulationSpeed = 0.1f;
    private bool modulationScaleIncreasing = true;
    public float modulationTime = 2f;
    private Vector3 originalPosition;
    public GameObject wallPiece;
    public float maxScaleIncreaseAmount = 2;
    public float maxZChangeAmount = 3; // Unused right now.
    private float distance;
    private float colliderRadius;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = wallPiece.transform.localScale;
        originalPosition = wallPiece.transform.position;
        SphereCollider col = GetComponent<SphereCollider>();
        colliderRadius = col.radius;

        // Start each wall piece at a random point within the scale range.
        wallPiece.transform.localScale = new Vector3(originalScale.x, Random.Range(originalScale.y, maxModulationScale), originalScale.z);
        originalScale = wallPiece.transform.localScale;
    }

    void Update() {
        if(modulationScaleIncreasing) {
            Vector3 velocity = new Vector3(0, modulationSpeed, 0);
            wallPiece.transform.localScale = Vector3.SmoothDamp(wallPiece.transform.localScale, new Vector3(originalScale.x, maxModulationScale, originalScale.z), ref velocity, modulationTime);
        } else {
            Vector3 velocity = new Vector3(0, -modulationSpeed, 0);
            // wallPiece.transform.localScale = new Vector3(currentScale.x, currentScale.y - (Time.deltaTime * modulationSpeed), currentScale.z);
            wallPiece.transform.localScale = Vector3.SmoothDamp(wallPiece.transform.localScale, new Vector3(1,1,1), ref velocity, modulationTime);
        }

        if(wallPiece.transform.localScale.y >= maxModulationScale) {
            modulationScaleIncreasing = false;
        } else if(wallPiece.transform.localScale.y <= 1) {
            modulationScaleIncreasing = true;
        }
    }

    // void onTriggerExit(Collider other) {
    //     wallPiece.transform.localScale = originalScale;
    //     // wallPiece.transform.position = originalPosition;
    // }

    // void OnTriggerStay(Collider other) {
    //     distance = Vector3.Magnitude(transform.position - other.transform.position);
    //     if(distance > colliderRadius) {
    //         return;
    //     }

    //     float modPercent = 1 - Mathf.Pow((distance / colliderRadius), 1);
    //     float modScaleAmount = maxScaleIncreaseAmount * modPercent;
    //     float modPositionAmount = maxZChangeAmount * modPercent; // Unused.
    //     wallPiece.transform.localScale = new Vector3(originalScale.x, originalScale.y + modScaleAmount, originalScale.z);
    //     // wallPiece.transform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z + modPositionAmount);
    // }
}
