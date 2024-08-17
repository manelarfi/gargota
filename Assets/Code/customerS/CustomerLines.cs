using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomerLines : MonoBehaviour
{
    public float customerWidth; // Width of each customer
    public Queue<GameObject> line1 = new Queue<GameObject>();
    public Queue<GameObject> line2 = new Queue<GameObject>();
    public Queue<GameObject> line3 = new Queue<GameObject>();

    public Transform[] customerLines;

    int minIndex;

    public Queue<GameObject> whichLine(int index) {
        switch(index) {
            case 1:
                return line1;

            case 2:
                return line2;

            case 3:
                return line3;

            default:
                return null;
        }
    }
    public Queue<GameObject> AddCustomerToLine(GameObject customer) {
        Queue<GameObject> updatedLine = null;
        minIndex = FindMin();
        switch (minIndex)
        {
            case 0:
                line1.Enqueue(customer);
                updatedLine = line1;
                break;
            case 1:
                line2.Enqueue(customer);
                updatedLine = line2;
                break;
            case 2:
                line3.Enqueue(customer);
                updatedLine = line3;
                break;
            default:
                Debug.LogError("Invalid line index.");
                break;
        }
        return updatedLine;
    }

    public int FindMin() {
        List<int> lineCounts = new List<int> {
            line1.Count,
            line2.Count,
            line3.Count
        };

        // Find the minimum count and return its index
        int minCount = lineCounts.Min();
        return lineCounts.IndexOf(minCount);
    }

    public Vector3 CalculateOffset(GameObject customer) {
        Queue<GameObject> updatedLine = AddCustomerToLine(customer);
        int nbCustomers = updatedLine.Count;
        Vector3 offset = new Vector3(customerLines[minIndex].transform.position.x + customerWidth * nbCustomers, customerLines[minIndex].transform.position.y, customerLines[minIndex].transform.position.z);
        return offset;
    }
}
