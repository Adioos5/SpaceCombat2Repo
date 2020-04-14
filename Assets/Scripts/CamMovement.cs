﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    public Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Refresh();
    }

    public void Refresh() {
        if (target == null) {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self) {
            transform.position = target.TransformPoint(offsetPosition);
        } else {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt) {
            transform.LookAt(target);
        } else {
            transform.rotation = target.rotation;
        }
    }
}