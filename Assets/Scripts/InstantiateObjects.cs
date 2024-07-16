using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectQuantity {
    public GameObject go;
    public int quantity;
}

public class InstantiateObjects : MonoBehaviour {

    [SerializeField]
    public List<ObjectQuantity> objects = new List<ObjectQuantity> { };

    private void Awake() {
        foreach (var obj in objects) {
            for (int i = 0; i < obj.quantity; i++) {
                Vector2 pos2d = UnityEngine.Random.insideUnitCircle * 100;
                Vector3 pos3d = new Vector3(pos2d.x - 10, 0.1f, pos2d.y - 10);
                //Instantiate(obj.pickableObject, this.transform + pos3d, Quaternion.identity);
                var go = Instantiate(obj.go, this.transform);
                go.transform.position = pos3d;
            }
        }
    }
}   
