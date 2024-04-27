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
 
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();

    }

    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

     
        if (distanceToPlayer <= detectionDistance)
        {
           
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

void OnCollisionEnter(Collision collision)
{

    if (collision.gameObject.CompareTag("Player"))
    {

        if (playerHealth != null)
        {
                playerHealth.TakeDamage();
        }
        speed = 0f;

    }
}
}