using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Audio")]
    public PlayerHealth playerHealth;
    private AudioSource playerAudioSource;
    [SerializeField] AudioClip enemyHitSound;

    [Header("Attack")]
    public float cooldownTime = 2f;
    private bool canDamage = true;
    public bool isHit = false;


    private void Start()
    {
        Transform player = gameObject.GetComponent<NewEnemyMovement>().playerTransform;
        playerAudioSource = player.GetComponent<AudioSource>();

        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && playerHealth != null && canDamage)
        {
            playerHealth.TakeDamage();
            StartCoroutine(StunAndDamageCooldown());
            
            playerAudioSource.PlayOneShot(enemyHitSound);
        }
    }


    IEnumerator StunAndDamageCooldown()
    {
        canDamage = false;
        isHit = true;

        yield return new WaitForSeconds(cooldownTime);

        canDamage = true;
        isHit = false;
    }
}
