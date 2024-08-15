using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;  // Required for LINQ methods

public class CustomerLines : MonoBehaviour
{
    public float customerWidth; // Width of each customer
    public List<GameObject> line1 = new List<GameObject>();
    public List<GameObject> line2 = new List<GameObject>();
    public List<GameObject> line3 = new List<GameObject>();
    public List<GameObject> line4 = new List<GameObject>();

    public Transform[] customerLines = new Transform[4];
    int minIndex;

    private void Start() {
        int i = 0;
        foreach(Transform point in GameManager.Instance.spawnPoints) {
            customerLines[i] = point;
            i++;
        }
    }

    // Adds a customer to the line with the fewest customers
    public List<GameObject> AddCustomerToLine(GameObject customer) {
        List<GameObject> updatedLine = null;
        minIndex = FindMin();
        switch (minIndex)
        {
            case 0:
                line1.Add(customer);
                updatedLine = line1;
                break;
            case 1:
                line2.Add(customer);
                updatedLine = line2;
                break;
            case 2:
                line3.Add(customer);
                updatedLine = line3;
                break;
            case 3:
                line4.Add(customer);
                updatedLine = line4;
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
            line3.Count,
            line4.Count
        };

        // Find the minimum count and return its index
        int minCount = lineCounts.Min();
        return lineCounts.IndexOf(minCount);
    }

    public Vector3 calculateOffset(GameObject customer) {
        List<GameObject> UpdatedLine = AddCustomerToLine(customer);
        int nbCustomers = UpdatedLine.Count();
        Vector3 offset = new Vector3(GameManager.Instance.spawnPoints[minIndex].transform.position.x - customerWidth * nbCustomers , GameManager.Instance.spawnPoints[minIndex].transform.position.y, GameManager.Instance.spawnPoints[minIndex].transform.position.z);
        Debug.Log(offset);
        return offset;
    }
    
}
