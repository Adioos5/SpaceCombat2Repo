using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool canUnlock = true;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private int smoothSteps = 10;

    [SerializeField]
    private float smoothWeight = 0.4f;

    [SerializeField]
    private float rollAngle = 10f;

    [SerializeField]
    private float rollSpeed = 3f;

    [SerializeField]
    private Vector2 defaultLookLimits = new Vector2(-70f, 80f);

    private Vector2 lookAngles;
    private Vector2 currentMouseLook;
    private Vector2 smoothMove;

    private float currentRollAngle;

    private int lastLookFrame;



    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        LockAndUnlockCursor();

        if (Cursor.lockState == CursorLockMode.Locked) {
            LookAround();
        }
    }

    void LockAndUnlockCursor() {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (Cursor.lockState == CursorLockMode.Locked) {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    void LookAround() {

        //Wektor widoku kamery
        currentMouseLook = new Vector2(Input.GetAxis(Tags.MOUSE_Y), Input.GetAxis(Tags.MOUSE_X));


        lookAngles.x += currentMouseLook.x * sensivity * (invert ? 1f : -1f);
        lookAngles.y += currentMouseLook.y * sensivity;

        //Zaciska kąt widoku
        lookAngles.x = Mathf.Clamp(lookAngles.x, defaultLookLimits.x, defaultLookLimits.y);

        //ŻEBY KURWA ZROBIĆ GOŚCIA PIJANEGO - OŚ Z
        currentRollAngle = Mathf.Lerp(currentRollAngle, Input.GetAxisRaw(Tags.MOUSE_X) * rollAngle, rollSpeed * Time.deltaTime);

        lookRoot.localRotation = Quaternion.Euler(lookAngles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, lookAngles.y, 0f);

    }
}
