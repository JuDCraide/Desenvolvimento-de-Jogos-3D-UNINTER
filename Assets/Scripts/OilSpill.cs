using System.Collections;
using UnityEngine;

public class OilSpill : MonoBehaviour {

    [SerializeField]
    private Sound slipSound;
    bool justSlip;

    IEnumerator waitToSlipAgain() {
        yield return new WaitForSeconds(0.5f);
        justSlip = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !justSlip) {
            justSlip = true;
            AudioManager.instance.Play(slipSound);
            //Debug.Log("Player " + other.gameObject.name);
            other.GetComponent<PickupController>().DropObjectOnImpact();
            waitToSlipAgain();
        }
    }

    private void OnTriggerExit(Collider other) {
        justSlip = false;
    }
}
