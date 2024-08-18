using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CompareFood : MonoBehaviour
{
    public scoreManager score;
    public int lineNB;
    public Order CustomerOrder;
    public GameObject waitingLines;
    public GameObject hands;
    public healthManager healthManager;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is "Pickupable" and has a "preparedOrder" component
        if (other.gameObject.CompareTag("Pickupable") && other.gameObject.GetComponent<preparedOrder>())
        {
            Debug.Log("Entered trigger with a prepared order");

            // Access the CustomerLines script
            CustomerLines customerLines = waitingLines.GetComponent<CustomerLines>();

            // Get the customer from the specified line
            Queue<GameObject> lineQueue = customerLines.whichLine(lineNB);
            if (lineQueue != null && lineQueue.Count > 0)
            {
                GameObject customer = lineQueue.Peek(); // Get the customer at the front of the queue

                // Get the CustomerOrder script from the customer
                CustomerOrder customerOrderScript = customer.GetComponent<CustomerOrder>();
                if (customerOrderScript != null)
                {
                    Order customerOrder = customerOrderScript.randomOrder;

                    // Compare orders
                    Order preparedOrderScript = other.GetComponent<preparedOrder>().order;
                    if (preparedOrderScript == customerOrder)
                    {
                        // Update positions of remaining customers in the line
                        foreach (var remainingCustomer in lineQueue)
                        {
                            NavMeshAgent agent = remainingCustomer.GetComponent<NavMeshAgent>();
                            agent.SetDestination(customerLines.updateOffset(lineQueue, remainingCustomer.transform));
                        }
                        score.scoreIncrease();
                        
                    }
                    else
                    {
                        // Orders don't match: player loses a heart
                        healthManager.looseHeart();
                    }

                        // Destroy both the customer and the prepared order
                        Destroy(other.gameObject);
                        Destroy(customer);
                        lineQueue.Dequeue(); // Remove the customer from the queue

                        // Update the isHolding status in the PickupSystem
                        PickupSystem pickupSystem = hands.GetComponent<PickupSystem>();
                        pickupSystem.isHolding = false;

                        // Update positions of remaining customers in the line
                        foreach (var remainingCustomer in lineQueue)
                        {
                            NavMeshAgent agent = remainingCustomer.GetComponent<NavMeshAgent>();
                            agent.SetDestination(customerLines.updateOffset(lineQueue, remainingCustomer.transform));
                        }
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
