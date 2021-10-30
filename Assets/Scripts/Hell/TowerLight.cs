using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerLight : MonoBehaviour
{
    private GameObject onFace;
    private GameObject offFace;
    private GameObject spotlight;

    // Start is called before the first frame update
    void Start()
    {
        Transform lightPivot = transform.Find("Light Pivot");
        onFace = lightPivot.Find("light face ON").gameObject;
        offFace = lightPivot.Find("light face STATIC").gameObject;
        spotlight = lightPivot.Find("Spot Light (1)").gameObject;
    }

    public void TurnOn() {
        onFace.SetActive(true);
        offFace.SetActive(false);
        spotlight.SetActive(true);
    }

    public void TurnOff() {
        onFace.SetActive(false);
        offFace.SetActive(true);
        spotlight.SetActive(false);
    }
}
