using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyPatrol : NewEnemyMovement
{
    [Header("Patrol")]
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float minDistance = 3;
    [SerializeField] private int randomNumber;

    [SerializeField] private float waitTime;
    private bool isWaiting;



    private void Awake()
    {
        randomNumber = Random.Range(0, movementPoints.Length);
    }

    public void EnemyPatrol()
    {
        Vector3 distanceToWaypoint = transform.position - movementPoints[randomNumber].position;

        if (distanceToWaypoint.x < minDistance && !isWaiting)
        {
            StartCoroutine(Wait());
        }
        else navMeshAgent.destination = (movementPoints[randomNumber].position);
    }

    
    IEnumerator Wait()
    {
        isWaiting = true;
        waitTime = Random.Range(0, 5);

        yield return new WaitForSeconds(waitTime);

        isWaiting = false;
        randomNumber = Random.Range(0, movementPoints.Length);
    }
}
