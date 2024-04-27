using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public HingeJoint Door;
    float targetVelocity = 30;
    // Start is called before the first frame update
    void Start()
    {
        Door = this.GetComponent<HingeJoint>();
        Door.useMotor = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.P)) {
            Door.useMotor = true;
            var motor = Door.motor;
            targetVelocity *= -1;
            motor.targetVelocity = targetVelocity;
            Door.motor = motor;
        }


    }
}
