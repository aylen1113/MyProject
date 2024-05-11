using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    //cambio nuevo
    [Header("Lógica")]
    public int maxHealth = 3;
    public int currentLives;
    public int LivesHealer;

    //public int health;
    //public int numOfHearts;

    [Header("UI")]
    public Image[] hearts;
    public Sprite fullPlushie;
    public Sprite emptyPlushie;

    public Animator animator;
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
        RecuperarHealth();
        ChequeoPlushies();
    }

    void OnCollissionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage();
            Debug.Log("Damage");
        }
    }

    public void TakeDamage()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOverScreen");
            Debug.Log("Game Over");

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

    public void RecuperarHealth()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((currentLives + LivesHealer) > maxHealth)
            {
                animator.SetTrigger("PlayerAbrazo");

                currentLives = maxHealth;
                
            }
            else
            {
                currentLives += LivesHealer;
            }
            Debug.Log("El nuevo nivel de vida es:" + currentLives);
            //collision.gameObject.SetActive(false);
        }

        //ChequeoPlushies();
    }
}
