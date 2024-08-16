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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (isHolding) {
                TryDropObject();
            } else {
                TryPickupObject();
            }
        }
    }

    private void TryPickupObject() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f); // Adjust radius as needed
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.CompareTag("Pickupable")) {
                PickupObject(hitCollider.gameObject);
                break;
            } else if (hitCollider.CompareTag("Spawner")) {
                spawnObject objectt = hitCollider.gameObject.GetComponent<spawnObject>();
                SpawnPickupObject(objectt.Prefab, objectt.Scale, objectt.objName);
            } else if (hitCollider.transform.TryGetComponent(out Interactable interactObj)) {
                interactObj.Interact();
                Debug.Log("Interacted");
            }
        }
    }

    private void TryDropObject() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f); // Adjust radius as needed
        foreach (var hitCollider in hitColliders) { 
            if (hitCollider.transform.TryGetComponent(out Interactable interactObj)) {
                interactObj.Interact();
                Interacted = true;
            }
        }

        if (!Interacted) {
            DropObject();
        } else {
            Interacted = false;  // Reset Interacted for future interactions
        }
    }

    public void SpawnPickupObject(GameObject obj, Vector3 scale, string ObjName) {
        GameObject newPickup = Instantiate(obj, holdPoint.position, Quaternion.identity, holdPoint);
        newPickup.transform.localScale = scale;
        newPickup.name = ObjName;
        heldObject = newPickup;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        isHolding = true;
    }

    public void PickupObject(GameObject obj) {
        heldObject = obj;
        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.position = holdPoint.position; // Adjust position as needed
        heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics interactions
        isHolding = true;
    }

    public void DropObject() {
        if (heldObject != null) {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics interactions
            heldObject = null;
            isHolding = false;
        }
    }
}
