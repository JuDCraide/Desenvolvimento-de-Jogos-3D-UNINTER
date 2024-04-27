using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, PressurePlateActivate
{
    public HingeJoint Door;
    public Rigidbody Rigidbody;
    JointMotor motor;
    float targetVelocity = 30;
    float force = 20;
    bool active = false;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.isKinematic = true;

        Door = GetComponent<HingeJoint>();
        motor = Door.motor;
        targetVelocity = motor.targetVelocity;
        force = motor.force;
        Door.useMotor = false;
        Door.useSpring = false;
    }

    public void Update() {
        //Door.useMotor = false;
        //Rigidbody.isKinematic = true;
    }

    public void Activate() {
        Debug.Log("Open Door");
        active = true;
        Rigidbody.isKinematic = false;
        Door.useMotor = true;
        motor.targetVelocity *= -1;
        Door.motor = motor;
    }

    IEnumerator waitToClose() {
        yield return new WaitForSeconds(5);
        if (active) yield break;
        Door.useSpring = true;
        yield return new WaitForSeconds(2);
        Rigidbody.isKinematic = true;
        Door.useSpring = false;
    }

    public void Deactivate() {
        active = false;
        Door.useMotor = false;
        Debug.Log("Stop Door");
        StartCoroutine(waitToClose());
    }
}
