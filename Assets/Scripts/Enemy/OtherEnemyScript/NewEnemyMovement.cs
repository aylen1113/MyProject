using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewEnemyMovement : MonoBehaviour
{
    [SerializeField] private float detectionDistance = 5f;
     protected Transform playerTransform;

    [Header("NavMesh")]
    NavMeshAgent navMeshAgent;



    protected void Awake()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        EnemyMovement();
    }

    public void FollowTarget(Transform target)
    {
        navMeshAgent.destination = target.position;
    }


    private void EnemyMovement()
    {
        if (!gameObject.GetComponent<EnemyAttack>().isHit)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) < detectionDistance)
            {
                FollowTarget(playerTransform);
            }
            else
            {
                gameObject.GetComponent<NewEnemyPatrol>().EnemyPatrol();
            }
        }
    }

}
