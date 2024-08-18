using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class customerSpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject prefabCustomer;
    CustomerLines customerLines;
    public GameObject lines;
    public Animator animator;
    

    private void Start() {
        lines = GameObject.FindWithTag("Lines");
        customerLines = lines.GetComponent<CustomerLines>();

        if(this.gameObject != null) {
            StartCoroutine(SpawnCustomer());
        }
    }
   

    IEnumerator SpawnCustomer() {
        while(true) {
           GameObject customer = Instantiate(prefabCustomer, transform.position, transform.rotation);
           NavMeshAgent agent = customer.GetComponent<NavMeshAgent>();
           agent.SetDestination(customerLines.CalculateOffset(customer));
           yield return new WaitForSeconds(spawnRate); 
        }
        
    }
}
