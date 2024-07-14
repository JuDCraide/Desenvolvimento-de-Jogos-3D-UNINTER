using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraFollows : MonoBehaviour {

    [SerializeField]
    public List<GameObject> cameras = new List<GameObject> { };
    public GameObject currentCam;

    void Start() {
        foreach (var cam in cameras) {
            cam.SetActive(false);
        }

        currentCam = cameras[0];
        currentCam.SetActive(true);
    }

    void Update() {
        for (int i = 0; i < cameras.Count; i++) {
            if (GetAlphaInputFromInt(i)) {
                if (cameras[i] != currentCam) {
                    currentCam.SetActive(false);
                    currentCam = cameras[i];
                    currentCam.SetActive(true);
                }
            }
        }
    }

    bool GetAlphaInputFromInt(int number) {
        switch (number + 1) {
            case 1: return Input.GetKey(KeyCode.Alpha1);
            case 2: return Input.GetKey(KeyCode.Alpha2);
            case 3: return Input.GetKey(KeyCode.Alpha3);
            case 4: return Input.GetKey(KeyCode.Alpha4);
            case 5: return Input.GetKey(KeyCode.Alpha5);
            case 6: return Input.GetKey(KeyCode.Alpha6);
            case 7: return Input.GetKey(KeyCode.Alpha7);
            case 8: return Input.GetKey(KeyCode.Alpha8);
            case 9: return Input.GetKey(KeyCode.Alpha9);
            default: return false;
        }
    }
}
