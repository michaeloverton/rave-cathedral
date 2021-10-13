using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMorpher1 : MonoBehaviour
{
    private Vector3 originalScale;
    public float maxScaleIncreaseAmount = 2;
    private float distance;
    private float colliderRadius;
    private Vector3 colliderCenter;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        SphereCollider col = GetComponent<SphereCollider>();
        colliderRadius = col.radius;
        colliderCenter = col.center;
    }

    void onTriggerExit(Collider other) {
        transform.localScale = originalScale;
    }

    void OnTriggerStay(Collider other) {
        // The strips of the wall are all somehow have same position vector.
        // The automatically generated sphere colliders are all offset - they centers that DO match the centers
        // of the real objects. We will find the real position of the object by subtracting the center of the collider value.
        // This will allow us to find true distance between player and object.

        Vector3 trueWallPosition = transform.position + colliderCenter;
        distance = Vector3.Magnitude(trueWallPosition - other.transform.position);
        if(distance > colliderRadius) {
            return;
        }

        float modPercent = 1 - Mathf.Pow((distance / colliderRadius), 1);
        float modAmount = maxScaleIncreaseAmount * modPercent;
        transform.localScale = new Vector3(originalScale.x, originalScale.y + modAmount, originalScale.z);
    }
}
