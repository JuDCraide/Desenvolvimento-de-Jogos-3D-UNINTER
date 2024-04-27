using UnityEngine;

public class ArmadilhaExplosao : MonoBehaviour, PressurePlateActivate {
    public float jumpExplosion = 1f;
    public float radius = 5f;
    public float forcaEmpurrar = 500f;
    public bool active = false;

    public void Empurrar() {
        Vector3 posicaoExplosao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, radius);
        int i = 0;
        foreach (Collider hit in colliders) {
            Debug.Log(i);
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(forcaEmpurrar, posicaoExplosao, radius, jumpExplosion);
            }
        }
    }

    public void Activate() {
        if (active) { return; }
        active = true;
        Empurrar();
    }

    public void Deactivate() {
        active = false;
    }
}
