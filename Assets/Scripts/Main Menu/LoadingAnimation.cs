using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingAnimation : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float spreadSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        text.characterSpacing += spreadSpeed * Time.deltaTime;
    }
}
