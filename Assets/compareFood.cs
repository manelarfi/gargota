using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareFood : MonoBehaviour
{
    public int lineNB;
    public Order CustomerOrder;
    public Order PreparedOrder;

    public GameObject waitingLines;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickupable")) {
            Debug.Log("hh");
        if (other.gameObject.GetComponent<preparedOrder>())
        {
            Debug.Log("Entered trigger with a prepared order");

            // Access the CustomerLines script
            CustomerLines customerLines = waitingLines.GetComponent<CustomerLines>();

            // Get the customer from the specified line
            Queue<GameObject> lineQueue = customerLines.whichLine(lineNB);
            if (lineQueue != null && lineQueue.Count > 0)
            {
                GameObject customer = lineQueue.Dequeue();
                Debug.Log("Customer found");

                // Get the CustomerOrder script from the customer
                CustomerOrder customerOrderScript = customer.GetComponent<CustomerOrder>();
                if (customerOrderScript != null)
                {
                    CustomerOrder = customerOrderScript.randomOrder;

                    // Compare orders
                    if (PreparedOrder == CustomerOrder)
                    {
                        // Destroy both the customer and the prepared order
                        Destroy(other.gameObject);
                        Destroy(customer);
                    }
                }
                else
                {
                    Debug.LogWarning("Customer does not have a CustomerOrder script.");
                }
            }
            else
            {
                Debug.LogWarning("Line queue is empty or invalid.");
            }
        }
    }
    }
}
