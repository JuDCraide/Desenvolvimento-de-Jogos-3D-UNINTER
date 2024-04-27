using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour {

    public Transform objectToFollow;
    public Rotate rotateFollower;
    public Vector3 offset;

    void Start() {
        offset = this.transform.position - objectToFollow.position;
    }

    void Update() {
        this.transform.position = objectToFollow.position + offset;
        //transform.LookAt(objectToFollow.forward * -1);
        //transform.Rotate(rotateFollower.horizontalRotation + offset);
    }
}
