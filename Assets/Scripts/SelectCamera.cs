using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {

    public GameObject camera1;
    public GameObject camera2;

    void Start() {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            camera1.SetActive(true);
            camera2.SetActive(false);
        }
        else if (Input.GetKey(KeyCode.Alpha2)) {
            camera2.SetActive(true);
            camera1.SetActive(false);
        }
    }
}
