using System;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderDisplay : MonoBehaviour
{
    public CustomerOrder customerOrder; // Reference to the CustomerOrder component
    public Sprite[] items; // Array to hold the sprites for different items
    public Image orderImage; // UI Image component to display the order image

    // Call this method to display the image based on the order
    public void ShowOrder()
    {
        if (customerOrder != null)
        {
            string orderType = customerOrder.randomOrder.ToString();

            switch (orderType)
            {
                case "Garantita":
                    orderImage.sprite = items[0]; // Set image for Garantita
                    break;
                case "pizza":
                    orderImage.sprite = items[1]; // Set image for Pizza
                    break;
            }

            orderImage.enabled = true; // Ensure the image is visible
        }
        else
        {
            orderImage.enabled = false; // Hide the image if no valid order is found
        }
    }
}
