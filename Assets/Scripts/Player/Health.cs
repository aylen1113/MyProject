using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour

{
    //    public Sprite full, empty;
    //    Image plushieImage;


    //    private void Awake()
    //    {
    //       plushieImage = GetComponent<Image>();
    //    }
    //    public void SetImage(HealthStatus status)
    //    {
    //        switch (status) {

    //            case HealthStatus.Empty:
    //            plushieImage.sprite = empty;
    //            break;

    //            case HealthStatus.Full:
    //            plushieImage.sprite = full;
    //            break;




    //        }
    //    }
    //}
    //public enum HealthStatus
    //{
    //    Empty = 0,
    //    Full = 1,
    //}

    public int health;
    public int numOfHearts;
    //public PlayerHealth current;

    public Image[] hearts;
    public Sprite fullPlushie;
    public Sprite emptyPlushie;

    private void Start()
    {
        GetComponent<PlayerHealth>().currentLives = health;
        //PlayerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        ChequeoPlushies();
    }
    //HOLA

    public void ChequeoPlushies ()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = fullPlushie;
            else
                hearts[i].sprite = emptyPlushie;

            if (i < numOfHearts)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
