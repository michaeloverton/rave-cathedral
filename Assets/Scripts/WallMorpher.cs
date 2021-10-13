using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMorpher : MonoBehaviour
{
    private Vector3 originalScale;
    private Vector3 originalPosition;
    public GameObject wallPiece;
    public float maxScaleIncreaseAmount = 2;
    public float maxZChangeAmount = 3;
    private float distance;
    private float colliderRadius;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = wallPiece.transform.localScale;
        originalPosition = wallPiece.transform.position;
        SphereCollider col = GetComponent<SphereCollider>();
        colliderRadius = col.radius;
    }

    void onTriggerExit(Collider other) {
        wallPiece.transform.localScale = originalScale;
        // wallPiece.transform.position = originalPosition;
    }

    void OnTriggerStay(Collider other) {
        distance = Vector3.Magnitude(transform.position - other.transform.position);
        if(distance > colliderRadius) {
            return;
        }

        float modPercent = 1 - Mathf.Pow((distance / colliderRadius), 1);
        float modScaleAmount = maxScaleIncreaseAmount * modPercent;
        float modPositionAmount = maxZChangeAmount * modPercent;
        wallPiece.transform.localScale = new Vector3(originalScale.x, originalScale.y + modScaleAmount, originalScale.z);
        // wallPiece.transform.position = new Vector3(originalPosition.x, originalPosition.y, originalPosition.z + modPositionAmount);
    }
}
