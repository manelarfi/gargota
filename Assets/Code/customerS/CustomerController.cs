using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    CustomerLines customerLines;
    public NavMeshAgent agent;
    public GameObject lines;
    

    private void Start() {
        lines = GameObject.FindWithTag("Lines");
        customerLines = lines.GetComponent<CustomerLines>();
        if(this.gameObject != null) {

            agent.SetDestination(Vector3.zero);
        }
    }
        
}
    

