using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator playerAnimator;
    private PlayerMovement playerMovement;

    private void Awake() {
        playerAnimator = GetComponent<Animator>();
    }

    public void SetBool(string key, bool value) {
        playerAnimator.SetBool(key, value);
    }

    public void SetTrigger(string key) {
        playerAnimator.SetTrigger(key);
    }

    public void PlayHitAnimation() {
        playerAnimator.SetTrigger(Tags.HIT);
    }
    public void PlayDeathAnimation() {
        playerAnimator.SetTrigger(Tags.DEATH);
    }
    public void PlayShootAnimation() {
        playerAnimator.SetTrigger(Tags.SHOOT);
    }

    public void PlayBackToLifeAnimation() {
        playerAnimator.SetTrigger(Tags.ALIVE);
    }

    public void PlayRunAnimation() {

        if (Input.GetKey(KeyCode.W)) {

            playerAnimator.SetBool(Tags.MOVING_FRONT, true);
            playerAnimator.SetBool(Tags.MOVING_BACK, false);
            playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
            playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);

        } else if (Input.GetKey(KeyCode.S)) {

            playerAnimator.SetBool(Tags.MOVING_FRONT, false);
            playerAnimator.SetBool(Tags.MOVING_BACK, true);
            playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
            playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);

        } else if (Input.GetKey(KeyCode.D)) {

            playerAnimator.SetBool(Tags.MOVING_FRONT, false);
            playerAnimator.SetBool(Tags.MOVING_BACK, false);
            playerAnimator.SetBool(Tags.MOVING_SIDE_R, true);
            playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);

        } else if (Input.GetKey(KeyCode.A)) {

            playerAnimator.SetBool(Tags.MOVING_FRONT, false);
            playerAnimator.SetBool(Tags.MOVING_BACK, false);
            playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
            playerAnimator.SetBool(Tags.MOVING_SIDE_L, true);
        }
    }

    public void PlayIdleAnimation() {
        playerAnimator.SetBool(Tags.MOVING_FRONT, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
        playerAnimator.SetBool(Tags.MOVING_BACK, false);
        playerAnimator.SetBool(Tags.JUMPING, false);
        playerAnimator.SetBool(Tags.AIMING, false);
        playerAnimator.SetBool(Tags.AIMING_WALKING, false);
    }

    public void PlayDanceAnimation() {
        playerAnimator.SetBool(Tags.DANCING, true);

    }

    public void PlayJumpAnimation() {
        playerAnimator.SetBool(Tags.MOVING_FRONT, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
        playerAnimator.SetBool(Tags.MOVING_BACK, false);
        playerAnimator.SetBool(Tags.JUMPING, true);
    }

    public void PlayAimAnimation() {
        playerAnimator.SetBool(Tags.MOVING_FRONT, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
        playerAnimator.SetBool(Tags.MOVING_BACK, false);
        playerAnimator.SetBool(Tags.JUMPING, false);
        playerAnimator.SetBool(Tags.AIMING, true);
        playerAnimator.SetBool(Tags.AIMING_WALKING, false);

    }
    public void PlayAimWalkAnimation() {
        playerAnimator.SetBool(Tags.MOVING_FRONT, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_L, false);
        playerAnimator.SetBool(Tags.MOVING_SIDE_R, false);
        playerAnimator.SetBool(Tags.MOVING_BACK, false);
        playerAnimator.SetBool(Tags.JUMPING, false);
        playerAnimator.SetBool(Tags.AIMING, true);
        playerAnimator.SetBool(Tags.AIMING_WALKING, true);

    }

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {     

        if (playerAnimator.GetBool(Tags.DANCING) == false) {

            if (playerAnimator.GetBool(Tags.JUMPING) == false && playerAnimator.GetBool(Tags.AIMING) == false) {
                if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) {
                    PlayIdleAnimation();
                } else {
                    PlayRunAnimation();
                }

                if (Input.GetKeyDown(KeyCode.L)) {
                    playerAnimator.SetBool(Tags.DANCING, true);

                }
            }
        } else if (playerAnimator.GetBool(Tags.DANCING) == true) {
            PlayDanceAnimation();

            if (Input.GetKeyDown(KeyCode.L)) {
                playerAnimator.SetBool(Tags.DANCING, false);

            }
        }
    }
}
