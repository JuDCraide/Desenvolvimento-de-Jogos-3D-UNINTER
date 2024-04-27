using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface PressurePlateActivate {
    public void Activate();
    public void Deactivate();
}

public class PressurePlate : MonoBehaviour, PressurePlateActivate {
    [SerializeField]
    public GameObject go;
    PressurePlateActivate activationObject;
    // Start is called before the first frame update
    public void Activate() {
        activationObject = go.GetComponent<PressurePlateActivate>();
        if (activationObject != null) {
            activationObject.Activate();
        }
    }

    public void Deactivate() {
        if (activationObject != null) {
            activationObject.Deactivate();
        }
    }
}