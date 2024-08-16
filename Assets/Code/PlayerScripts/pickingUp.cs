using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    private Transform holdPoint; 
    private GameObject heldObject; 
    public bool isHolding = false; 
    private bool Interacted = false;

    private void Start() {
        GameObject hands = GameObject.FindWithTag("hands");
        holdPoint = hands.GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            if (isHolding)
            {
                DropObject();
            }
            else
            {
                TryPickupObject();
            }
        }
    }

    private void TryPickupObject()
    {
        // Raycast or collision detection logic to find objects in range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f); // Adjust radius as needed
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Pickupable"))
            {
                PickupObject(hitCollider.gameObject);
                break;
            } else if (hitCollider.CompareTag("Spawner"))
            {
                spawnObject objectt = hitCollider.gameObject.GetComponent<spawnObject>();
                SpawnPickupObject(objectt.Prefab, objectt.Scale, objectt.objName);

            }
        }
    }

    public void SpawnPickupObject(GameObject obj, Vector3 scale, String ObjName) {
        GameObject newPickup = Instantiate(obj, holdPoint.position, Quaternion.identity, holdPoint);
        newPickup.transform.localScale = scale;
        newPickup.transform.name = ObjName;
        newPickup.transform.position = holdPoint.position;
        heldObject = newPickup;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        isHolding = true;
    }

    public void PickupObject(GameObject obj)
    {
        heldObject = obj;
        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.position = holdPoint.position; // Adjust position as needed
        heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics interactions
        isHolding = true;
    }

    private void DropObject()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (var hitCollider in hitColliders) {
            if(hitCollider.transform.TryGetComponent(out Interactable InteractObj)) {
                InteractObj.Interact();
                Interacted = true;
                Debug.Log("Interacted");
            }
        }
        if (Interacted == false) {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics interactions
            heldObject = null;
            isHolding = false; 
        } else {
            Interacted = false;
        }
        
    }
}
