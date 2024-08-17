using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Order
{
    Garantita,
    empty
}

public class CustomerOrder : MonoBehaviour
{
    public Order randomOrder;
    void Start()
    {
        // Get a random value from the Order enum
        randomOrder = GetRandomEnumValue<Order>();
        Debug.Log("Random Order: " + randomOrder);
    }

    // Generic method to get a random enum value
    T GetRandomEnumValue<T>()
    {
        // Get all values from the enum
        T[] enumValues = (T[])System.Enum.GetValues(typeof(T));
        // Generate a random index
        int randomIndex = UnityEngine.Random.Range(0, enumValues.Length);
        // Return the enum value at the random index
        return enumValues[randomIndex];
    }
}
