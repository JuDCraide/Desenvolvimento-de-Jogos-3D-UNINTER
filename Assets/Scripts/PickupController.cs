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
    public LayerMask m_LayerMask;

    [SerializeField]
    private float pickupRange = 5.0f;
    [SerializeField]
    private float pickupForce = 150.0f;

    [SerializeField]
    private Sound pickUp;
    [SerializeField]
    private Sound drop;

    void Start() {
    }

    void Update() {
        if (heldObj == null) {
            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                bool rayDidHit = Physics.Raycast(ray, out hit, m_LayerMask);
                float distance = Vector3.Distance(transform.position, hit.point);
                //Debug.Log(distance);
                if (rayDidHit && distance <= pickupRange) {
                    PickupObject(hit.transform.gameObject);
                }
            }
        }
        else {
            if (Input.GetMouseButtonDown(1)) {
                DropObject();
            }
            else {
                MoveObject();
            }
        }
    }

    void PickupObject(GameObject pickObj) {
        if (pickObj.tag == "Player" || pickObj.tag == "Brick") {
            return;
        }
        if (pickObj.GetComponent<Rigidbody>()) {
            AudioManager.instance.Play(pickUp);

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
        AudioManager.instance.Play(drop);
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObjRB.transform.parent = null;
        heldObj.transform.position = dropPosition.transform.position;
        heldObj = null;
    }

    public float RandomBoolValue() {
        var i = Random.Range(-10, 11);
        return i / 10.0f;
    }

    public void DropObjectOnImpact() {
        //Debug.Log("DropObjectOnImpact");
        if (heldObj != null) {
            heldObjRB.useGravity = true;
            heldObjRB.drag = 1;
            heldObjRB.constraints = RigidbodyConstraints.None;

            heldObjRB.transform.parent = null;
            heldObjRB.AddForce(transform.up * 600);
            Debug.Log(RandomBoolValue());
            heldObjRB.AddTorque(heldObj.transform.forward * 3000 * RandomBoolValue());
            heldObj = null;
        }
    }

    void MoveObject() {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f) {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }

}
