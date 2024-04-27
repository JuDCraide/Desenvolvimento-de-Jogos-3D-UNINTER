using UnityEngine;

public class ArmadilhaExplosao : MonoBehaviour, PressurePlateActivate {
    public float jumpExplosion = 1f;
    public float radius = 5f;
    public float pushForce = 500f;
    public bool active = false;

    public void Explosion() {
        Vector3 posicaoExplosao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(pushForce, posicaoExplosao, radius, jumpExplosion);
            }
        }
    }

    public void Activate() {
        if (active) { return; }
        active = true;
        Explosion();
    }

    public void Deactivate() {
        active = false;
    }
}
