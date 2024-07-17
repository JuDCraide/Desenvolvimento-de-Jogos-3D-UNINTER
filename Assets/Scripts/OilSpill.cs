using System.Collections;
using UnityEngine;

public class OilSpill : MonoBehaviour {

    [SerializeField]
    private Sound slipSound;
    bool justSlip;

    IEnumerator waitToSlipAgain() {
        yield return new WaitForSeconds(1);
        justSlip = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !justSlip) {
            justSlip = true;
            AudioManager.instance.Play(slipSound);
            //Debug.Log("Player " + other.gameObject.name);
            other.GetComponent<PickupController>().DropObjectOnImpact();
        }
    }
}
