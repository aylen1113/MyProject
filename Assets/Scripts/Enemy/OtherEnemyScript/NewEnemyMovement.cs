using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyMovement : MonoBehaviour
{
    [SerializeField] protected float detectionDistance = 5f;
    public Transform playerTransform;

    [Header("NavMesh")]
    protected NavMeshAgent navMeshAgent;



    protected void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        EnemyMovement();
    }


    private void EnemyMovement()
    {
        if (!gameObject.GetComponent<EnemyAttack>().isHit)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) > detectionDistance)
            {
                gameObject.GetComponent<NewEnemyPatrol>().EnemyPatrol();
            }
            else 
                navMeshAgent.destination = playerTransform.position;
        }
    }
}


