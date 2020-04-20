using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorProblem : MonoBehaviour
{

    void Tagging(Transform transform) {
        transform.gameObject.tag = "Floor";

        foreach (Transform t in transform) {
            Tagging(t);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Tagging(transform);
    }


}
