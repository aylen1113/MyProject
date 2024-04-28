using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Lógica")]
    public int maxHealth = 3;
    public int currentLives;

    //public int health;
    //public int numOfHearts;

    [Header("UI")]
    public Image[] hearts;
    public Sprite fullPlushie;
    public Sprite emptyPlushie;

    private void Start()
    {
        currentLives = maxHealth;
    }

    private void Update()
    {
        if (currentLives > maxHealth)
        {
            currentLives = maxHealth;
        }
        ChequeoPlushies();
    }

    #region Code
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

    public void ChequeoPlushies()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentLives)
                hearts[i].sprite = fullPlushie;
            else
                hearts[i].sprite = emptyPlushie;

            if (i < maxHealth)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
    #endregion
}
