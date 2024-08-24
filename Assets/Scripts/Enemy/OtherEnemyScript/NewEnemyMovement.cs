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
            Vector3 distanceToPlayer = transform.position - playerTransform.position;

            if (distanceToPlayer.x < detectionDistance)
            {
                navMeshAgent.destination = playerTransform.position;
            }
            else
                gameObject.GetComponent<NewEnemyPatrol>().EnemyPatrol();
        }
    }
}


