using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public WheelJoint2D wheel1, wheel2;
    public Joint2D head;
    public bool forceWheel1, forceWheel2;
    public float minCorrectionTorque = 20, maxCorrectionTorque, collectionCorrectionTorque;

    [HideInInspector]
    public bool isSecondPlayer = false;
    
    private float torqueInertia = 0;
    private Collider2D headCollider;
    private Rigidbody2D myRb;
    private bool motor = false;
    private bool reverse = false;

	// Use this for initialization
	void Start () {
        myRb = GetComponent<Rigidbody2D>();
        headCollider = head.connectedBody.gameObject.GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (forceWheel1)
            ForceWheel(wheel1);
        if (forceWheel2)
            ForceWheel(wheel2);

        if (motor) {
            torqueInertia = Math.Sign(torqueInertia) *
                Math.Max(Math.Min(Math.Abs(torqueInertia), maxCorrectionTorque), minCorrectionTorque);
            if (torqueInertia != 0f)
                Debug.Log(torqueInertia);
            myRb.AddTorque(torqueInertia * (isSecondPlayer ? 1 : -1));
        }
        

        if (headCollider.IsTouchingLayers()) {
            FindObjectOfType<GameLoader>().StopGame(this);
        }
    }

    void Update() {
        bool fwd;
        bool bwd;

        if (!isSecondPlayer) {
            fwd = Input.GetKey(KeyCode.LeftArrow);
            bwd = Input.GetKey(KeyCode.RightArrow);
        } else {
            fwd = Input.GetKey(KeyCode.A);
            bwd = Input.GetKey(KeyCode.D);
        }

        CheckPolarity();

        motor = fwd && !bwd || !fwd && bwd;
        reverse = bwd;

        if (motor) {
            float delta = collectionCorrectionTorque * Time.deltaTime * (reverse ? -1 : 1);
            if (delta < 0f && torqueInertia > 0f || delta > 0f && torqueInertia < 0f) {
                torqueInertia = 0f;
            } else {
                torqueInertia += delta;
            }
        } else {
            torqueInertia = 0f;
        }
    }

    private void CheckPolarity() {
        bool isFlipped = transform.localScale.x < 0f;
        if (isFlipped != isSecondPlayer) {
            Vector3 trans = transform.localScale;
            trans.x *= -1;
            transform.localScale = trans;
        }
    }

    private void ForceWheel(WheelJoint2D wheel) {
        JointMotor2D whMotor = wheel.motor;
        whMotor.motorSpeed = Mathf.Abs(wheel.motor.motorSpeed) * (reverse ? -1 : 1);
        wheel.motor = whMotor;
        wheel.useMotor = motor;
    }
}
