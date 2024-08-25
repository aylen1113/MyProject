using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolEnemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float waitTime = 2f;
    [SerializeField] private float stoppingDistance = 0.5f;  

    private int currentWaypoint = 0;
    private bool isWaiting = false;

    void Update()
    {

        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) > stoppingDistance)
        {
            
            navMeshAgent.destination = waypoints[currentWaypoint].position;
        }
        else if (!isWaiting)
        {
     
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;  
        yield return new WaitForSeconds(waitTime);  
        currentWaypoint++;  

        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0; 
        }
        isWaiting = false; 
    }
}
