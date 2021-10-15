using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private int width;
    private int height;
    public float remappedWidthMin = 46.5f;
    public float remappedHeightMin = -29.3f;
    public float remappedWidthMax = -51.5f;
    public float remappedHeightMax = 29.7f;

    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float x = map(mousePos.x, 0, width, remappedWidthMin, remappedWidthMax);
        float y = map(mousePos.y, 0, height, remappedHeightMin, remappedHeightMax);
        transform.position = new Vector3(23, y, x);
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s-a1)*(b2-b1)/(a2-a1);
    }
}
