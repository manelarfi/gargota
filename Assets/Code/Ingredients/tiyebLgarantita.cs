using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TiyebLgarantita : MonoBehaviour, Interactable
{
    private AudioManager audioManager;

    bool hasEnded = false;
    private GameObject prefab;
    public GameObject Garantitatayba;
    public GameObject pizzaTayba;
    private float timer;
    private GameObject hands;
    private PickupSystem pickupSystem;
    public int cookingTime = 10;
    public timerOven timerOven;
    private string result;

    private void Start() {
        hands = GameObject.FindGameObjectWithTag("hands");
        pickupSystem = hands.GetComponent<PickupSystem>();
        // Find the GameObject with the tag "Audio"
        GameObject audioObject = GameObject.FindWithTag("Audio"); 
        audioManager = audioObject.GetComponent<AudioManager>();
    }

    public void Interact() {
        if (hands.transform.childCount > 0 && (hands.transform.GetChild(0).name == "sniwabGarantitaNC" || hands.transform.GetChild(0).name == "sniwapizzaNC")) 
        {
            audioManager.PlaySFX(audioManager.timer);
            HandleRawFood();
        } 
        else if (hands.transform.childCount == 0 && Time.realtimeSinceStartup - timer > cookingTime) 
        {
            audioManager.PlaySFX(audioManager.wjd);
            SpawnCookedFood();
        }
    }

    private void HandleRawFood() {
        var heldObjectName = hands.transform.GetChild(0).name;
        if (heldObjectName == "sniwabGarantitaNC") {
            result = "sniwabGrantita";
            prefab = Garantitatayba;
        } else if (heldObjectName == "sniwapizzaNC") {
            result = "sniwaPizza";
            prefab = pizzaTayba;
        }

        Debug.Log("Destroying object in hands");
        Destroy(hands.transform.GetChild(0).gameObject);
        pickupSystem.isHolding = false;
        timer = Time.realtimeSinceStartup;
        timerOven.StartTimer(cookingTime);
    }

    private void SpawnCookedFood() {
        Debug.Log("Spawning cooked garantita");
        pickupSystem.SpawnPickupObject(prefab, result);
    }
}
