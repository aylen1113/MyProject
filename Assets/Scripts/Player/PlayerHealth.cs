using UnityEngine;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentLives;

    private void Start()
    {
        currentLives = maxHealth;
    }

    private void OnCollissionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            Debug.Log("Damage");
        }
    }

  public  void TakeDamage()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            Debug.Log("Game Over");
     
        }
        else
        {
            Debug.Log("Lost a life. Lives left: " + currentLives);
      
        }
    }
}
