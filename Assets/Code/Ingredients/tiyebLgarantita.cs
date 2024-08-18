using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiyebLgarantita : MonoBehaviour, Interactable
{
    public GameObject garantitaTayba;
    public Vector3 scale;
    private float timer;
    private GameObject hands;
    private PickupSystem pickupSystem;
    public float cookingTime;

    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
        
    }

    public void Interact() {
        Debug.Log("heyhey");

        if (hands.transform.childCount > 0 && hands.transform.GetChild(0).name == "sniwabGarantitaNC") {
            Debug.Log("Destroying object in hands");
            Destroy(hands.transform.GetChild(0).gameObject);
            pickupSystem.isHolding = false;
            timer = Time.realtimeSinceStartup;
        } 
        else if (hands.transform.childCount == 0 && Time.realtimeSinceStartup - timer > cookingTime) {
            Debug.Log("Spawning cooked garantita");
            timer = Time.realtimeSinceStartup;
            pickupSystem.SpawnPickupObject(garantitaTayba,"sniwabGrantita");
        }
    }
}
