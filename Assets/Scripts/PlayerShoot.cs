using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerShoot : MonoBehaviour
{
    public GameObject parentShot;

    public Transform bulletSpawn;

    public Text ammoText;

    public CamMovement camMovement;

    private AnimationHandler animationHandler;
    private PlayerMovement playerMovement;
    private AudioManager audioManager;

    private int magazine;
    private int ammoLoad;
    private int currentLoad;

    // Start is called before the first frame update
    void Awake()
    {
        magazine = 120;
        ammoLoad = 20;
        currentLoad = 20;

        playerMovement = GetComponent<PlayerMovement>();
        animationHandler = GetComponent<AnimationHandler>();
        audioManager = GetComponent<AudioManager>();
        parentShot.active = false;
        
    }

    // Update is called once per frame
    void Update() {
        HandleAiming();

    }

    private void InitShot() {

        GameObject newShot = Instantiate(parentShot) as GameObject;

        newShot.active = true;

        newShot.transform.parent = bulletSpawn;
        newShot.transform.localPosition = new Vector3(bulletSpawn.localPosition.x + 0.2f, bulletSpawn.localPosition.y + 1.5f, bulletSpawn.localPosition.z + 0.6f);
        newShot.transform.localRotation = bulletSpawn.localRotation;
        newShot.transform.eulerAngles = new Vector3(newShot.transform.eulerAngles.x, newShot.transform.eulerAngles.y + 180, newShot.transform.eulerAngles.z);
        newShot.transform.parent = null;

        newShot.GetComponent<Rigidbody>().AddForce(-newShot.transform.forward * 1500f);

        newShot.AddComponent<DestroyAliens>();

        audioManager.PlayShotSound();
    }

    void HandleAmmoCounter() {
        
        if (currentLoad > 0) {
            currentLoad--;
            InitShot();
        } else {
            if (magazine != 0) {
                if (magazine >= ammoLoad) {
                    // animationHandler.PlayReloadAnimation();
                    magazine -= ammoLoad;
                    currentLoad = ammoLoad;
                } else {
                    currentLoad = magazine;
                    magazine = 0;
                }
            } else {
                // audioManager.PlayEmptyMagazineSound();
            } 
        }

        ammoText.text = currentLoad + "/" + magazine;

    }

    void HandleAiming() {

        if (Input.GetButton(Tags.FIRE2)) {
            camMovement.offsetPosition.y = 1.95f;
            camMovement.offsetPosition.z = -2.3f;

            if (Input.GetButtonDown(Tags.FIRE1)) {
                animationHandler.PlayShootAnimation();
                HandleAmmoCounter();
                
            }

            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !playerMovement.isFlying) {
                animationHandler.PlayAimWalkAnimation();
            } else {
                animationHandler.PlayAimAnimation();

            }


        } else if (Input.GetButtonUp(Tags.FIRE2)) {
            camMovement.offsetPosition.y = 2f;
            camMovement.offsetPosition.z = -4;

            animationHandler.PlayIdleAnimation();
           
        }
    }

}
