using UnityEngine;

public class Explosion : MonoBehaviour, PressurePlateActivate {
    public float jumpExplosion = 1f;
    public float radius = 5f;
    public float pushForce = 500f;
    public bool active = false;

    public void Explode() {
        Vector3 posicaoExplosao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(pushForce, posicaoExplosao, radius, jumpExplosion);
            }
            if (hit.tag == "Player") {
                //Debug.Log("Player " + hit.gameObject.name);
                hit.GetComponent<PickupController>().DropObjectOnImpact();
            }
        }
        active = false;
    }

    public void Activate() {
        if (active) { return; }
        active = true;
        Explode();
    }

    public void Deactivate() {
        active = false;
    }
}
