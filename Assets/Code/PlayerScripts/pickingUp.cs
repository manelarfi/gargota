using System;
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
        if (Input.GetKeyDown(KeyCode.F)) {
            if (isHolding) {
                TryDropObject();
            } else {
                TryPickupObject();
            }
        }
    }

    private void TryPickupObject() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.CompareTag("Pickupable")) {
                PickupObject(hitCollider.gameObject);
                break;
            } else if (hitCollider.CompareTag("Spawner")) {
                spawnObject objectt = hitCollider.gameObject.GetComponent<spawnObject>();
                SpawnPickupObject(objectt.Prefab, objectt.objName);
            } else if (hitCollider.transform.TryGetComponent(out Interactable interactObj)) {
                interactObj.Interact();
                Debug.Log("Interacted");
            }
        }
    }

    private void TryDropObject() {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.transform.TryGetComponent(out Interactable interactObj)) {
                interactObj.Interact();
                Interacted = true;
            }
        }

        if (!Interacted) {
            DropObject();
        } else {
            Interacted = false;
        }
    }

    public void SpawnPickupObject(GameObject obj, string ObjName) {
        PickupData data = obj.GetComponent<dataScript>().data;
        GameObject newPickup = Instantiate(obj, holdPoint.position, Quaternion.identity, holdPoint);
        
        // Apply the data from PickupData
        newPickup.transform.localPosition = data.positionInHand;
        newPickup.transform.localRotation = Quaternion.Euler(data.rotationInHand);
        newPickup.transform.localScale = data.scaleInHand;
        
        newPickup.name = ObjName;
        heldObject = newPickup;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        isHolding = true;
    }

    public void PickupObject(GameObject obj) {
        // Access the PickupData from the object
        PickupData data = obj.GetComponent<dataScript>().data;

        heldObject = obj;
        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.localPosition = data.positionInHand;
        heldObject.transform.localRotation = Quaternion.Euler(data.rotationInHand);
        heldObject.transform.localScale = data.scaleInHand;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
        isHolding = true;
    }

    public void DropObject() {
        if (heldObject != null) {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            isHolding = false;
        }
    }
}
