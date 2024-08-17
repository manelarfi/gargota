using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSandwich : MonoBehaviour, Interactable
{
    GameObject hands;
    PickupSystem pickupSystem;
    public GameObject khobzGarantita;
    public GameObject pizzaPlate;
    public int servings;
    String assem;
    GameObject prefab;
    int i = 0;

    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands?.GetComponent<PickupSystem>();
        
        if(hands == null || pickupSystem == null) {
            Debug.LogError("Hands or PickupSystem not found!");
        }
    }

    public void Interact () {
        if(hands != null && hands.transform.childCount > 0) {
            String currentObj = hands.transform.GetChild(0).name;
            
            if(currentObj == "khobz" || currentObj == "plate")
            {
                if(currentObj == "khobz") {
                    Debug.Log("KHOBZ");
                    prefab = khobzGarantita;
                    assem = "khobz";
                } else {
                    prefab = pizzaPlate;
                    assem = "pizzaPlate";
                    Debug.Log("PLATE");
                }

                if(i <= servings) {
                    Destroy(hands.transform.GetChild(0).gameObject);
                    Debug.Log("SPAWNA");
                    pickupSystem.SpawnPickupObject(prefab, assem);
                    if(i == servings) {
                        Destroy(transform.GetChild(0).gameObject);
                    transform.name = "sniwa";
                    }
                    i++;
                } 
            
            } else if (currentObj == "sniwabGrantita" || currentObj == "sniwaPizza") {
                pickupSystem.DropObject();
            }
        } else if (hands.transform.childCount == 0) {
            Debug.Log("No object in hand, picking up the sandwich.");
            pickupSystem.PickupObject(transform.gameObject);
        } else {
            Debug.Log("Unexpected condition or error in the process.");
        }
    }
}
