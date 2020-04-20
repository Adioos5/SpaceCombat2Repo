using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public GameObject particles;
    public GameObject mesh;
    private Vector3 moveDirection;
    public float speed = 10f;
    private float verticalVelocity;
    private float gravity = 20f;
    private IEnumerator coroutine2;
    private bool wasDeathTriggered = false;
    public GameObject laserBeam;
    public GameObject distanceMeasurer;

    //The target player
    public Transform player;
    
    public void Die() {

        if (!wasDeathTriggered) {
            wasDeathTriggered = true;
            StartCoroutine(coroutine2);
        }
    }

    private IEnumerator PlayDeathAnimation() {

        float vaporizingTime = 0.3f;

        mesh.SetActive(false);
        particles.SetActive(true);
        speed = 0f;

        //Glitch korutyny
        yield return new WaitForSeconds(vaporizingTime);
        yield return new WaitForSeconds(vaporizingTime);

        Destroy(gameObject);
        
    }

    void Start() {
        coroutine2 = PlayDeathAnimation();
    }

    //Call every frame
    void Update() {

        if (Vector3.Distance(laserBeam.GetComponent<BoxCollider>().ClosestPointOnBounds(transform.position), transform.position) < Vector3.Distance(laserBeam.GetComponent<BoxCollider>().ClosestPointOnBounds(distanceMeasurer.transform.position), distanceMeasurer.transform.position)) {
            Die();
        }

        //Look at the player
            transform.LookAt(player);

        moveDirection = transform.TransformDirection(Vector3.forward);
        moveDirection *= speed * Time.deltaTime;

        verticalVelocity -= gravity * Time.deltaTime;

        moveDirection.y = verticalVelocity * Time.deltaTime;

        transform.GetComponent<CharacterController>().Move(moveDirection);
    }
    
}
