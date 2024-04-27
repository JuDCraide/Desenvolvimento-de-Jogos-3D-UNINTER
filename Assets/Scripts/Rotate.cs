using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Character c;
    public float rotationSpeed = 150;
    public float pushPower = 5.0f;
    public Vector3 horizontalRotation;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // Rotate car sides
        horizontalRotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(horizontalRotation);
        c.forward = transform.forward;
    }

    private void OnTriggerEnter(Collider other) {
        Rigidbody body = other.attachedRigidbody;
        //Debug.Log(other.gameObject.tag);
        //Debug.Log(body.gameObject.tag);

        //Debug.Log("Colision start");
        if (other.gameObject.CompareTag("PressurePlate")) {
            //Debug.Log("PressurePlate ");
            PressurePlate pressurePlate = body.GetComponent<PressurePlate>();
            pressurePlate.Activate();
            return;
        }
        if (body == null || body.isKinematic) {
            return;
        }
        //if (hit.moveDirection.y < -0.3) {
        //    return;
        //}
        Debug.Log("Colision");

        //Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = /*pushDir*/ c.forward * pushPower;
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
