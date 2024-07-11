using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    [SerializeField]
    Transform holdArea;
    [SerializeField]
    Transform dropPosition;
    private GameObject heldObj = null;
    private Rigidbody heldObjRB;

    [SerializeField]
    private float pickupRange = 5.0f;
    [SerializeField]
    private float pickupForce = 150.0f;

    void Start() {
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (heldObj == null) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool rayDidHit = Physics.Raycast(ray, out hit);
                float distance = Vector3.Distance(transform.position, hit.point);
                Debug.Log(distance);
                if (rayDidHit && distance <= pickupRange) {
                    PickupObject(hit.transform.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            DropObject();
        }
        if (heldObj != null) {
            MoveObject();
        }
    }

    void PickupObject(GameObject pickObj) {
        if (pickObj.tag == "Player") {
            return;
        }
        if (pickObj.GetComponent<Rigidbody>()) {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.transform.rotation = Quaternion.identity;
            heldObjRB.transform.forward = transform.forward;
            heldObjRB.transform.position = holdArea.transform.position;
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ; ;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject() {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj.transform.position = dropPosition.transform.position;
        heldObj = null;

    }

    void MoveObject() {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

}
