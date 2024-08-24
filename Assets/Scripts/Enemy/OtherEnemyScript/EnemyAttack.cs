using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack :NewEnemyMovement
{
    [Header("Audio")]
    public PlayerHealth playerHealth;
    private AudioSource playerAudioSource;
    [SerializeField] AudioClip enemyHitSound;

    [Header("Attack")]
    public float cooldownTime = 5f;
    private bool canDamage = true;
    public bool isHit = false;


    private void Start()
    {
        playerAudioSource = playerTransform.GetComponent<AudioSource>();
        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerHealth != null && canDamage)
            {
                playerHealth.TakeDamage();
                StartCoroutine(StunAndDamageCooldown());

                playerAudioSource.PlayOneShot(enemyHitSound);
            }
        }
    }


    IEnumerator StunAndDamageCooldown()
    {
        canDamage = false;
        isHit = false;

        yield return new WaitForSeconds(cooldownTime);

        canDamage = true;
        isHit = true;
    }
}
