using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillSniwa : MonoBehaviour, Interactable
{
    GameObject hands;
    public Vector3 Scale;
    PickupSystem pickupSystem;
    public GameObject sniwaWithGarantitaNC;
    //NC stands for not cooked
    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
    }
    public void Interact () {
        if(hands.transform.GetChild(0).name == "sniwa") 
        {
            Destroy(hands.transform.GetChild (0).gameObject);
            pickupSystem.SpawnPickupObject(sniwaWithGarantitaNC, Scale, "sniwabGarantitaNC");
        }
    }

}
