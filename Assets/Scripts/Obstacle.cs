using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        //Debug.Log(collision.relativeVelocity.magnitude);
        var colGO = collision.gameObject;
        if (colGO.tag == "Player") {
            if (collision.relativeVelocity.magnitude > 8.0) {           
                colGO.GetComponent<PickupController>().DropObjectOnImpact();
                colGO.GetComponent<CarController>().PlayCrashSound();
            } else {
                colGO.GetComponent<CarController>().PlaySmallCrashSound();
            }
        }
    }
}
