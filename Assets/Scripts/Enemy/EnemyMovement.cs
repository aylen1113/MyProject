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

    private Animator animator;
    private bool enemyRun = false;

    private bool canDamage = true;
    public float cooldownTime = 5f; 

    // NavMesh
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] bool followPlayer;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerAudioSource = playerTransform.GetComponent<AudioSource>();
        //animator = GetComponent<Animator>();
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
        //animator.SetBool("EnemyRun", true);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
                canDamage = false;
                StartCoroutine(EnableDamageAfterCooldown());

                if (enemyHitSound != null && playerAudioSource != null)
                {
                    playerAudioSource.PlayOneShot(enemyHitSound);
                }
            }
            //animator.SetBool("EnemyRun", false);
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
    IEnumerator EnableDamageAfterCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canDamage = true;
    }
}
