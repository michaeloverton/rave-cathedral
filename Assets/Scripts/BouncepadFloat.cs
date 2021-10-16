using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncepadFloat : MonoBehaviour
{
    public float cycleTime = 2f;
    public float floatSpeed = 2f;
    public float maxHeightIncrease = 2f;
    private bool up = true;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;

        // Randomize the starting position.
        transform.position = new Vector3(originalPosition.x, Random.Range(originalPosition.y, originalPosition.y + maxHeightIncrease), originalPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(up) {
            Vector3 velocity = new Vector3(0, floatSpeed, 0);
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(originalPosition.x, originalPosition.y + maxHeightIncrease, originalPosition.z), ref velocity, cycleTime);
        } else {
            Vector3 velocity = new Vector3(0, -floatSpeed, 0);
            transform.position = Vector3.SmoothDamp(transform.position, originalPosition, ref velocity, cycleTime);
        }

        if(transform.position.y >= originalPosition.y + maxHeightIncrease) {
            up = false;
        } else if(transform.position.y <= originalPosition.y) {
            up = true;
        }
    }
}
