using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyPatrol : NewEnemyMovement
{
    [Header("Patrol")]
    [SerializeField] private Transform[] movementPoints;
    [SerializeField] private float minDistance;
    [SerializeField] private int randomNumber;

    [SerializeField] private float waitTime;
    private bool isWaiting;



    private void Awake()
    {
        randomNumber = Random.Range(0, movementPoints.Length);
    }

    public void EnemyPatrol()
    {
        navMeshAgent.destination = (movementPoints[randomNumber].position);

        float distanceToPoint = Vector3.Distance(transform.position, movementPoints[randomNumber].position);

        if (distanceToPoint < minDistance)
        {
            randomNumber = Random.Range(0, movementPoints.Length);
        }


    }

    /*
    IEnumerator Wait()
    {
        isWaiting = true;

        yield return new WaitForSeconds(waitTime);

        isWaiting = false;
        randomNumber = Random.Range(0, movementPoints.Length);
    }
    */


}
