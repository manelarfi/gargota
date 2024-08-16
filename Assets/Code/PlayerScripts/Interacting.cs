using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacting : MonoBehaviour
{
    
    private Transform holdPoint; 
    private GameObject heldObject; 
    private bool Interacted = false;
    GameObject hands;
    PickupSystem pickupSystem;


    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (pickupSystem.isHolding)
            {
                checkInteraction();
            }
        }
    }

    private void checkInteraction() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (var hitCollider in hitColliders)
        { 
            if(hitCollider.transform.TryGetComponent(out Interactable interactObj))
            {
                interactObj.Interact();
            }
        }
    }
}
