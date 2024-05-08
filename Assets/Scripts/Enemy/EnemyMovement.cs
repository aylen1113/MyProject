using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float detectionDistance = 5f; 

    private Transform playerTransform;
    public PlayerHealth playerHealth;

    private AudioSource playerAudioSource;
    [SerializeField] AudioClip enemyHitSound;

    private bool isHit = false;

    // NavMesh
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] bool followPlayer;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerAudioSource = playerTransform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isHit)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (distanceToPlayer <= detectionDistance && followPlayer)
            {
                //transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
                FollowPlayer();
            }
        }
    }

    public void FollowPlayer()
    {
        navMeshAgent.destination = playerTransform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();

                if (enemyHitSound != null && playerAudioSource != null)
                {
                    playerAudioSource.PlayOneShot(enemyHitSound);
                }
            }
            StartCoroutine(StunEnemy());
        }
    }

    IEnumerator StunEnemy()
    {
        isHit = true;
        speed = 0f;

        yield return new WaitForSeconds(5f);

        isHit = false;
        speed = 8f;
    }
}