using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour {
    private CharacterController controller;
    public float movementSpeed = 2;
    public float gravidade = 9.81f;

    public Vector3 forward = Vector3.zero;

    public LayerMask groundLayer;
    public AnimationCurve curve;
    public float time = 0.25f;

    private void Start() {
        controller = GetComponent<CharacterController>();
    }

    void Update() {
        // Vertical movement
        controller.SimpleMove(forward * Input.GetAxis("Vertical") * movementSpeed);
        // Horizontal movement / fall gravity
        controller.Move(Vector3.down * gravidade * Time.deltaTime);

        // Rotate car slope
        Ray ray = new Ray(controller.transform.position, -controller.transform.up);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, groundLayer)) {
            Quaternion rotationXZ = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, hit.normal), curve.Evaluate(time));
            controller.transform.rotation = Quaternion.Euler(rotationXZ.eulerAngles.x, controller.transform.eulerAngles.y, rotationXZ.eulerAngles.z);
        }
    }
}