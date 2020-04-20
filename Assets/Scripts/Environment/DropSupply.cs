using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropSupply : MonoBehaviour
{
    public GameObject parachute;
    public GameObject box;
    private bool firstTime = true;
    private bool opened = false;
    public GameObject player;
    public GameObject drops;

    void OnTriggerEnter(Collider col) {
        if (firstTime) {
            transform.GetComponent<Rigidbody>().drag = 0.1f;
            Destroy(parachute);
            firstTime = false;
            transform.parent.GetComponent<SuppliesSpawner>().isSupplyGrounded = true;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>().velocity.magnitude < 0.01 && firstTime) {
            Destroy(parachute);
            transform.parent.GetComponent<SuppliesSpawner>().isSupplyGrounded = true;
            firstTime = false;
        }

        if (Vector3.Distance(transform.position, player.transform.position) < 5f && !firstTime && !opened) {
            transform.parent.GetComponent<SuppliesSpawner>().isSupplyOpened = true;
            opened = true;
            Destroy(box);
            drops.GetComponent<Drop>().ShowDropUp();
            
        }

    }
}
