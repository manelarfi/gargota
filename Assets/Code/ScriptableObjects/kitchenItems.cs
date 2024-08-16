using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "KitchenItems/Item")]
public class kitchenItems : ScriptableObject
{
    public String itemName;
    public Vector3 PosInHand;
    public Vector3 RotInHand;
    public Vector3 scalInHand;
    public GameObject prefab;
}
