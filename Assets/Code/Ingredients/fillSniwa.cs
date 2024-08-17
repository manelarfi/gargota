using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fillSniwa : MonoBehaviour, Interactable
{
    GameObject hands;
    PickupSystem pickupSystem;
    public String name;
    public String condition;
    public GameObject sniwaWithGarantitaNC;

    private void Start()
    {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
    }

    public void Interact()
    {
        if (hands.transform.childCount > 0 && hands.transform.GetChild(0).name == condition)
        {
            Destroy(hands.transform.GetChild(0).gameObject);
            pickupSystem.SpawnPickupObject(sniwaWithGarantitaNC, name);
        }
    }
}
