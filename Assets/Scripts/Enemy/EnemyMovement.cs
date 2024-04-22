using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float detectionDistance = 5f; 

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
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
            //PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            //if (playerHealth != null)
            //{
            //    playerHealth.TakeDamage(damage);
            //}
            speed = 0f;

        }
    }
}