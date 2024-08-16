using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeSandwich : MonoBehaviour, Interactable
{
    GameObject hands;
    public Vector3 Scale;
    PickupSystem pickupSystem;
    public GameObject khobzGarantita;
    public int servings;
    int i = 0;
    //NC stands for not cooked
    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
    }
    public void Interact () {
        Debug.Log("ani dkhelt");
        if(hands.transform.childCount > 0) {
            Debug.Log("he is choosing");
            if(hands.transform.GetChild(0).name == "khobz") 
            {
                Debug.Log("rahou ghalet");
                if(i < servings) {
                    Destroy(hands.transform.GetChild(0).gameObject);
                    pickupSystem.SpawnPickupObject(khobzGarantita, Scale, "khobzGarantita");
                    i++;
                } else {
                    Destroy(transform.GetChild (0).gameObject);
                    transform.name = "sniwa";
                }
            
            } else if (hands.transform.GetChild(0).name == "sniwabGrantita") {
                Debug.Log("rahou s7i7");
                pickupSystem.DropObject();
            }
        } else {
            Debug.Log("wtf?");
            pickupSystem.PickupObject(transform.gameObject);
        }
        
    }

}
