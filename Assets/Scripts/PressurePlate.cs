using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public interface PressurePlateActivate {
    public void Activate();
    public void Deactivate();
}

public class PressurePlate : MonoBehaviour, PressurePlateActivate {
    [SerializeField]
    public GameObject go;
    PressurePlateActivate activationObject;

    private void Start() {
        activationObject = go.GetComponent<PressurePlateActivate>();
    }

    public void Activate() {        
        if (activationObject != null) {
            activationObject.Activate();
        }
    }

    public void Deactivate() {
        if (activationObject != null) {
            activationObject.Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other) {
        Activate();
    }

    private void OnTriggerExit(Collider other) {
        Deactivate();
    }

}