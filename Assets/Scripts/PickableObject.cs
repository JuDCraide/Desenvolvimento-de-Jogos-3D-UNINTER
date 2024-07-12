using UnityEngine;

public enum PickableObjectType {
    Tire,
    Box1,
    Box2,
    Barrel,
}

public class PickableObject : MonoBehaviour {
    [SerializeField]
    public PickableObjectType type;
    public int points = 100;
    public Sprite objectImage;
}
