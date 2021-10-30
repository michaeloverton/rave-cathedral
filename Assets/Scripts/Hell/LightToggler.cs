using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToggler : MonoBehaviour
{
    public List<TowerLight> towers;
    public float switchTime;
    private float timer = 0;
    private int[] onLights = new int[3]; // Indices of the lights currently on in the towers array.

    // 3*n, (3*n) + 1, (3*n) + 2 are the groups
    // There are 8 total groups.

    // Start is called before the first frame update
    void Start()
    {
        // Turn on the first triple of lights.
        onLights[0] = 0;
        onLights[1] = 1;
        onLights[2] = 2;

        towers[0].TurnOn();
        towers[1].TurnOn();
        towers[2].TurnOn();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= switchTime) {
            // Turn off the currently on lights.
            towers[onLights[0]].TurnOff();
            towers[onLights[1]].TurnOff();
            towers[onLights[2]].TurnOff();

            // Turn on a random set of next lights.
            int nextGroup = Random.Range(0, 7);
            int indexZero = 3 * nextGroup;
            int indexOne = (3*nextGroup) + 1;
            int indexTwo = (3*nextGroup) + 2;

            onLights[0] = indexZero;
            onLights[1] = indexOne;
            onLights[2] = indexTwo;

            towers[indexZero].TurnOn();
            towers[indexOne].TurnOn();
            towers[indexTwo].TurnOn(); 

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
