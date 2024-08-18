using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerTimer : MonoBehaviour
{
    bool hasEnded= false;
    public CustomerOrderDisplay customerOrderDisplay;
    public Animator animator;
    public int customerWaitTime = 30;
    public timerOven timerOven;  // Changed from timerOven to TimerOven to match C# naming conventions
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!agent.pathPending)
        {
            // Check if the agent has reached its destination
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                // Ensure the agent has stopped moving
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    agent.updateRotation = false;
                    timerOven.StartTimer(customerWaitTime);
                    animator.SetBool("rahouDjay", false);
                    customerOrderDisplay.ShowOrder();
                    
                    this.enabled = false;

                }
            }
        }
    }
}
