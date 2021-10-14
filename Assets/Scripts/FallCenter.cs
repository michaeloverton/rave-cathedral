using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is a hack. It forces the player to (0,y,0) as we are falling to track 3.
public class FallCenter : MonoBehaviour
{
    public CharacterController player;
    public int factor;

    void OnTriggerEnter(Collider other) {
        player.Move(new Vector3(-player.gameObject.transform.position.x/factor, 0, -player.gameObject.transform.position.z/factor));
    }
}
