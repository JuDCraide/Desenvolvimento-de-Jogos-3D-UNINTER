using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour, PressurePlateActivate {
    public HingeJoint Door;
    public Rigidbody Rigidbody;
    JointMotor motor;
    bool active = false;

    [SerializeField]
    private Sound doorhinge;

    void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.isKinematic = true;

        Door = GetComponent<HingeJoint>();
        motor = Door.motor;
        Door.useMotor = false;
        Door.useSpring = false;
    }

    public void Activate() {
        //Debug.Log("Open Door");
        AudioManager.instance.Play(doorhinge);
        active = true;
        Rigidbody.isKinematic = false;
        Door.useMotor = true;
        Door.motor = motor;

        StartCoroutine(waitToStopOpening());
    }
    
    IEnumerator waitToStopOpening() {
        yield return new WaitForSeconds(3);
        AudioManager.instance.Stop(doorhinge);
    }

    IEnumerator waitToClose() {
        yield return new WaitForSeconds(5);
        if (active) yield break;
        Door.useSpring = true;
        AudioManager.instance.Play(doorhinge);
        yield return new WaitForSeconds(3);
        Rigidbody.isKinematic = true;
        Door.useSpring = false;
        AudioManager.instance.Stop(doorhinge);
    }

    public void Deactivate() {
        active = false;
        Door.useMotor = false;
        //Debug.Log("Stop Door");
        StartCoroutine(waitToClose());
    }
}
