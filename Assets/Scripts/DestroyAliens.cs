using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAliens : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag!="Floor")
            Destroy(col.gameObject);

        Destroy(gameObject);
    }
    
}
