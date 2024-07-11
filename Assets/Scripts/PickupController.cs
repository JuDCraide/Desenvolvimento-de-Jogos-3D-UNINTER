using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour {

    [SerializeField]
    Transform holdArea;
    private GameObject heldObj = null;
    private Rigidbody heldObjRB;

    [SerializeField]
    private float pickupRange = 5.0f;
    [SerializeField]
    private float pickupForce = 1000.0f;

    void Start() {

    }

    void Update() {
        Debug.Log("UPDATE");
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("MouseDown");
            if (heldObj == null) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //bool rayDidHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange);
                bool rayDidHit = Physics.Raycast(ray, out hit);
                Debug.Log(rayDidHit);
                if (rayDidHit) {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else {
                DropObject();
            }
        }
        if (heldObj != null) {
            MoveObject();
        }
    }

    void PickupObject(GameObject pickObj) {
        if (pickObj.GetComponent<Rigidbody>()) {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject() {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj = null;
        
    }

    void MoveObject() {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

}
