using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Character c;
    public float rotationSpeed = 150;
    public float pushPower = 5.0f;
    public Vector3 horizontalRotation;

    void Update() {
        // Rotate car sides
        horizontalRotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(horizontalRotation);
        c.forward = transform.forward;
    }

    private void OnTriggerEnter(Collider other) {
        Rigidbody body = other.attachedRigidbody;

        if (other.gameObject.CompareTag("PressurePlate")) {
            PressurePlate pressurePlate = body.GetComponent<PressurePlate>();
            pressurePlate.Activate();
            return;
        }
        if (body == null || body.isKinematic) {
            return;
        }
        //Debug.Log("Colision");

        // Apply the push on objects
        body.velocity = c.forward * pushPower;
        Vector3 pushDir = (body.transform.position - this.transform.position).normalized;

        body.velocity = pushDir * pushPower * Input.GetAxis("Vertical");

    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("PressurePlate")) {
            PressurePlate pressurePlate = other.gameObject.GetComponent<PressurePlate>();
            pressurePlate.Deactivate();
        }
    }
}
