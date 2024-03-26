using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Character c;
    public float rotationSpeed = 150;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // Rotate car sides
        Vector3 horizontalRotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(horizontalRotation);
        c.forward = transform.forward;
    }
}
