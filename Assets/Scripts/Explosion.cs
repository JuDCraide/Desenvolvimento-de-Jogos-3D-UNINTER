using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour {
    public float jumpExplosion = 1f;
    public float radius = 5f;
    public float pushForce = 500f;

    [SerializeField]
    private Sound explosionSound;

    bool justExploded = false;

    public void Explode() {
        AudioManager.instance.Play(explosionSound);
        Vector3 posicaoExplosao = transform.position;
        Collider[] colliders = Physics.OverlapSphere(posicaoExplosao, radius);
        foreach (Collider hit in colliders) {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (hit.tag == "Player") {
                //Debug.Log("Player " + hit.gameObject.name);

                rb.AddExplosionForce(pushForce * 10, posicaoExplosao, radius, jumpExplosion);
                hit.GetComponent<PickupController>().DropObjectOnImpact();
            }
            else if (rb != null) {
                rb.AddExplosionForce(pushForce, posicaoExplosao, radius, jumpExplosion);
            }
        }
    }

    IEnumerator waitToExploddeAgain() {
        yield return new WaitForSeconds(5);
        justExploded = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !justExploded) {
            Explode();
            justExploded = true;
            StartCoroutine(waitToExploddeAgain());
        }
    }
}
