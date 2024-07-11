using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum PickableObjectType {
    Tire,
    Box1,
    Box2,
    Barrel,
}

public class PickableObject : MonoBehaviour
{
    [SerializeField]
    public PickableObjectType type;
    public int points = 100;
}
