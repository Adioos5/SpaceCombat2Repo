using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private AnimationHandler animationHandler;

    public GameObject flame1;
    public GameObject flame2;

    private CharacterController characterController;

    private Vector2 lookAngles;
    private Vector2 currentMouseLook;

    private Vector3 moveDirection;

    private float sensivity = 5f;
    public float speed = 15f;
    private float gravity = 20f;
    public float jumpForce = 10f;
    private float verticalVelocity;

    [HideInInspector]
    public bool isFlying = false;

    private LineRenderer line;

    private Thread thread;

    private void Awake() {
        characterController = GetComponent<CharacterController>();
        animationHandler = GetComponent<AnimationHandler>();
        flame1.SetActive(false);
        flame2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        flame1.transform.localRotation = flame1.transform.parent.localRotation;
        flame2.transform.localRotation = flame2.transform.parent.localRotation;
        HandleBasicActions();

        currentMouseLook = new Vector2(Input.GetAxis(Tags.MOUSE_Y), Input.GetAxis(Tags.MOUSE_X));
        lookAngles.y += currentMouseLook.y * sensivity;

        transform.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);
       
        MoveThePlayer();
    }

    private void MoveThePlayer() {
        moveDirection = new Vector3(Input.GetAxis(Tags.HORIZONTAL), 0f, Input.GetAxis(Tags.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);

        
    }

    private void ApplyGravity() {
        verticalVelocity -= gravity * Time.deltaTime;

        PlayerJump();

        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    private void PlayerJump() {

        if(characterController.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            verticalVelocity = jumpForce;
            isFlying = true;
            animationHandler.PlayJumpAnimation();
            flame1.SetActive(true);
            flame2.SetActive(true);
        } else if(characterController.isGrounded && !Input.GetKeyDown(KeyCode.Space)) {
            isFlying = false;
            animationHandler.SetBool(Tags.JUMPING, false);
            flame1.SetActive(false);
            flame2.SetActive(false);
        }
        


    }

    void HandleBasicActions() {

        if (Input.GetKeyDown(KeyCode.O)) {
            animationHandler.PlayIdleAnimation();
            animationHandler.PlayHitAnimation();
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            animationHandler.PlayIdleAnimation();
            animationHandler.PlayDeathAnimation();

        }

        if (Input.GetKeyDown(KeyCode.I)) {
            animationHandler.PlayBackToLifeAnimation();
        }
    }
}
