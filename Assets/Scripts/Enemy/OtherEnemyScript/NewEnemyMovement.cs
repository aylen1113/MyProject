using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyMovement : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
    [SerializeField] protected Transform playerTransform;

    [Header("NavMesh")]
    [SerializeField] protected NavMeshAgent navMeshAgent;



    protected void Awake()
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
            if (Vector3.Distance(transform.position, playerTransform.position) < detectionDistance)
            {
                navMeshAgent.destination = playerTransform.position;
            }
            else
            {
                gameObject.GetComponent<NewEnemyPatrol>().EnemyPatrol();
            }
        }
    }

}
