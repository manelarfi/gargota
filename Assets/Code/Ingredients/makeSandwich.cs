using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSandwich : MonoBehaviour, Interactable
{
    private GameObject hands;
    private PickupSystem pickupSystem;
    public GameObject khobzGarantita;
    public GameObject pizzaPlate;
    public int servings;
    private string assem;
    private GameObject prefab;
    private int i = 0;

    // NC stands for not cooked
    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands?.GetComponent<PickupSystem>();
        
        if (hands == null || pickupSystem == null) {
            Debug.LogError("Hands or PickupSystem not found!");
        }
    }

    public void Interact() {
        if (hands != null && hands.transform.childCount > 0) {
            string currentObj = hands.transform.GetChild(0).name;
            
            if (currentObj == "khobz" || currentObj == "plate") {
                HandleBreadOrPlate(currentObj);
            } else if (currentObj == "sniwabGrantita" || currentObj == "sniwaPizza") {
                pickupSystem.DropObject();
                Debug.Log("Dropped object: " + currentObj);
            }
        } else if (hands != null && hands.transform.childCount == 0) {
            Debug.Log("No object in hand, picking up the sandwich.");
            pickupSystem.PickupObject(transform.gameObject);
        } else {
            Debug.LogWarning("Unexpected condition or error in the process.");
        }
    }

    private void HandleBreadOrPlate(string currentObj) {
        if (currentObj == "khobz") {
            prefab = khobzGarantita;
            assem = "khobz";
            Debug.Log("Chosen: KHOBZ");
        } else {
            prefab = pizzaPlate;
            assem = "pizzaPlate";
            Debug.Log("Chosen: PLATE");
        }

        if (i < servings) {
            Destroy(hands.transform.GetChild(0).gameObject);
            pickupSystem.SpawnPickupObject(prefab, assem);
            i++;
            Debug.Log("Spawned prefab: " + assem);

            if (i == servings) {
                Destroy(transform.GetChild(0).gameObject);
                transform.name = "sniwa";
                Debug.Log("All servings used, transforming object to 'sniwa'");
            }
        }
    }
}
