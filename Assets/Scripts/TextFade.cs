using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFade : MonoBehaviour
{
    public TextMeshProUGUI text;
    private float distance;
    private float colliderRadius;

    // Start is called before the first frame update
    void Start()
    {
        colliderRadius = GetComponent<SphereCollider>().radius;
    }

    void OnTriggerEnter(Collider other) {
        text.enabled = true;
    }

    void OnTriggerExit(Collider other) {
        text.enabled = false;
    }

    void OnTriggerStay(Collider other) {
        text.alpha = 1;

        // distance = Vector3.Magnitude(transform.position - other.transform.position);
        // float fadePercent = 1 - (distance / colliderRadius);
        // text.alpha = fadePercent;
    }
}
