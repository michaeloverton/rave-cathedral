using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using TMPro;

public class TitleTextController : MonoBehaviour
{
    public GameObject trackOneSubheader;
    public GameObject trackOneTitle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(trackOneDisplay());
    }

    IEnumerator trackOneDisplay() 
    {
        yield return new WaitForSeconds(1);
        trackOneSubheader.SetActive(true);

        yield return new WaitForSeconds(2);
        trackOneTitle.SetActive(true);

        yield return new WaitForSeconds(4);
        trackOneSubheader.SetActive(false);
        trackOneTitle.SetActive(false);
    }
}
