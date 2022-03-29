using UnityEngine;

[CreateAssetMenu(fileName = "New Car", menuName = "Car")]
public class CarObj : ScriptableObject
{
    public Sprite carSprite;

    public float driftFactor;
    public float accelerationFactor;
    public float turningFactor;
    public float breakForce;
    public float DragOnRoad;
    public float DragOnDirt;
}
