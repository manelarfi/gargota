using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiyebLgarantita : MonoBehaviour, Interactable
{
    GameObject prefab;
    public GameObject Garantitatayba;
    public GameObject pizzaTayba;
    private float timer;
    private GameObject hands;
    private PickupSystem pickupSystem;
    public float cookingTime;
    private String result;

    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
    }

    public void Interact() {
        if (hands.transform.childCount > 0 && (hands.transform.GetChild(0).name == "sniwabGarantitaNC" || hands.transform.GetChild(0).name == "sniwapizzaNC")) {
            if(hands.transform.GetChild(0).name == "sniwabGarantitaNC") {
                result = "sniwabGrantita";
                prefab = Garantitatayba;
            } else {
                result = "sniwaPizza";
                prefab = pizzaTayba;
            }
            pickupSystem.isHolding = false;
            Destroy(hands.transform.GetChild(0).gameObject);
            timer = Time.realtimeSinceStartup;
            
        } else if (hands.transform.childCount == 0 && Time.realtimeSinceStartup - timer > cookingTime) {
            timer = Time.realtimeSinceStartup;
            pickupSystem.SpawnPickupObject(prefab, result);
        }
    }
}
