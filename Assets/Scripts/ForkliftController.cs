using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CarController : MonoBehaviour {
    public enum Axel {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel {
        public GameObject gameObject;
        public WheelCollider collider;
        public Axel axel;
    }

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    float verticalInput;
    float horizontalInput;
    bool breakInput;

    float speed;

    public List<Wheel> wheels;
    public Rigidbody rb;

    public Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator.SetBool("IsMovingForward", false);
        animator.SetBool("IsMovingBackwards", false);
    }

    void Update() {
        GetInputs();
    }

    void LateUpdate() {
        Move();
        Steer();
        Break();
    }

    private void FixedUpdate() {
        AnimateMoveForward();
        AnimateTurn();
    }

    void GetInputs() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
        breakInput = Input.GetKey(KeyCode.Space);
    }

    void Move() {
        foreach (Wheel wheel in wheels) {
            wheel.collider.motorTorque = verticalInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer() {
        foreach (Wheel wheel in wheels) {
            if (wheel.axel == Axel.Front) {
                var steerAngle = horizontalInput * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, steerAngle, 0.6f);
            }
        }
    }

    void Break() {
        if (Input.GetKey(KeyCode.Space)) {
            foreach (Wheel wheel in wheels) {
                wheel.collider.brakeTorque = 600 * brakeAcceleration * Time.deltaTime;
            }
        }
        else {
            foreach (Wheel wheel in wheels) {
                wheel.collider.brakeTorque = 0;
            }
        }
    }

    void AnimateMoveForward() {
        speed = transform.InverseTransformDirection(rb.velocity).z;
        //Debug.Log($"{speed} {Mathf.Abs(speed) < 0.1f} {breakInput}");
        if (Mathf.Abs(speed) < 1f || breakInput) {
            animator.SetBool("IsMovingForward", false);
            animator.SetBool("IsMovingBackwards", false);
        }
        else if (speed > 0f) {
            animator.SetBool("IsMovingForward", true);
            animator.SetBool("IsMovingBackwards", false);
        }
        else if (speed < 0f) {
            animator.SetBool("IsMovingForward", false);
            animator.SetBool("IsMovingBackwards", true);
        }
    }

    void AnimateTurn() {
        //Debug.Log($"{horizontalInput} {Mathf.Approximately(horizontalInput, 0f)}");
        if (Mathf.Approximately(horizontalInput, 0f)) {
            animator.SetBool("IsTurningLeft", false);
            animator.SetBool("IsTurningRight", false);
        }
        else if (horizontalInput < 0f) {
            animator.SetBool("IsTurningLeft", true);
            animator.SetBool("IsTurningRight", false);
        }
        else if (horizontalInput > 0f) {
            animator.SetBool("IsTurningLeft", false);
            animator.SetBool("IsTurningRight", true);
        }
    }
}
