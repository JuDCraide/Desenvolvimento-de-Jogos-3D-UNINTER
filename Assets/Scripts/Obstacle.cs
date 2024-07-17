using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > 8.0) {
            var colGO = collision.gameObject;
            if (colGO.tag == "Player") {
                colGO.GetComponent<PickupController>().DropObjectOnImpact();
                colGO.GetComponent<CarController>().PlayCrashSound();
            }
        }
    }
}
