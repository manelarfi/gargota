using UnityEngine;

[CreateAssetMenu(fileName = "NewPickupData", menuName = "Pickup Data", order = 51)]
public class PickupData : ScriptableObject
{
    public Vector3 scaleInHand;
    public Vector3 positionInHand;
    public Vector3 rotationInHand;
}
