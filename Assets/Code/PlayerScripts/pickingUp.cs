using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    private Transform holdPoint; 
    private GameObject heldObject; 
    private bool isHolding = false; 

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
            }
        }
    }

    private void PickupObject(GameObject obj)
    {
        heldObject = obj;
        heldObject.transform.SetParent(holdPoint);
        heldObject.transform.position = holdPoint.position; // Adjust position as needed
        heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics interactions
        isHolding = true;
    }

    private void DropObject()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics interactions
        heldObject = null;
        isHolding = false;
    }
}
