using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float detectionDistance = 5f; 

    private Transform player;
    public PlayerHealth playerHealth;

    private AudioSource playerAudioSource;
    [SerializeField] AudioClip enemyHitSound;

    private bool isHit = false;
 
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerAudioSource = player.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isHit)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
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