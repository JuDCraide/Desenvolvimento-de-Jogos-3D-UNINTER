using UnityEngine;

public class OilSpill : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //Debug.Log("Player " + other.gameObject.name);
            other.GetComponent<PickupController>().DropObjectOnImpact();
        }
    }
}
