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

    public List<Wheel> wheels;
    public Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        GetInputs();
        // AnimateWheels();
    }

    void LateUpdate() {
        Move();
        Steer();
        Break();
    }

    void GetInputs() {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");
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
                wheel.collider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;
            }
        }
        else {
            foreach (Wheel wheel in wheels) {
                wheel.collider.brakeTorque = 0;
            }
        }
    }

    //void AnimateWheels() {
    //    foreach (Wheel wheel in wheels) {
    //        Quaternion rot;
    //        Vector3 pos;
    //        wheel.collider.GetWorldPose(out pos, out rot);
    //        wheel.gameObject.transform.position = pos;
    //        wheel.gameObject.transform.rotation = rot;
    //    }
    //}
}
