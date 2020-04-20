using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAliens : MonoBehaviour
{   
    void OnTriggerEnter(Collider col) {

        if (gameObject.tag!="Alien") {
            if (col.gameObject.tag != "Floor" && col.gameObject.tag != "Supply") {
                col.gameObject.GetComponent<ChasePlayer>().Die();
            }

            Destroy(gameObject);
        }
    }

    
}
