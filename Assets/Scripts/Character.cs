using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {
    //private CharacterController controller;
    private Rigidbody rb;
    public float movementSpeed = 20f;
    public float rotationSpeed = 10f;
    //public float gravidade = 9.81f;

    public Vector3 forwardPosition = Vector3.zero;

    public LayerMask groundLayer;
    public AnimationCurve curve;
    public float time = 0.25f;
    public bool isAcelerating = false;

    public float horizontalInput = 0;

    private void Start() {
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        forwardPosition = transform.forward;
    }

    void Update() {
        //    // Vertical movement
        //    //controller.SimpleMove(forward * Input.GetAxis("Vertical") * movementSpeed);
        //    // Horizontal movement / fall gravity
        //    //controller.Move(Vector3.down * gravidade * Time.deltaTime);

            horizontalInput = Input.GetAxis("Vertical");
        //    isAcelerating = !Mathf.Approximately(horizontalInput, 0f);

        //    var moveForward = forward * horizontalInput * movementSpeed * Time.deltaTime;
        //    var fallDown = Vector3.down * gravidade * Time.deltaTime;
        //    rb.MovePosition(rb.position + moveForward + fallDown);

        //    // Rotate car slope
        //    //Ray ray = new Ray(rb.position, -transform.up);
        //    //RaycastHit hit = new RaycastHit();
        //    //if (Physics.Raycast(ray, out hit, groundLayer)) {
        //    //    Quaternion rotationXZ = Quaternion.Lerp(rb.rotation, Quaternion.FromToRotation(Vector3.up, hit.normal), curve.Evaluate(time));
        //    //    rb.MoveRotation(Quaternion.Euler(rotationXZ.eulerAngles.x, rb.rotation.eulerAngles.y, rotationXZ.eulerAngles.z));
        //    //}
    }

    void FixedUpdate() {
        isAcelerating = !Mathf.Approximately(horizontalInput, 0f);
        if (isAcelerating) {
            //var rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * rotationSpeed, 0);
            //rb.MoveRotation(Quaternion.RotateTowards(rb.position, rotation, 10f));
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * rotationSpeed);
            //forwardPosition = transform.forward;
        }

        Vector3 moveForward = Vector3.forward * horizontalInput * movementSpeed;
        Debug.Log($"{forwardPosition}, {horizontalInput}, {movementSpeed}");
        rb.AddRelativeForce(moveForward);
    }

}