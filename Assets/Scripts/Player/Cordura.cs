using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cordura : MonoBehaviour
{
    #region variables
    public float MaxSanity = 15; //variable fija
    public float Sanity;
    [SerializeField] private float SanityHealer;
    public CorduraSlider sanitybar;
    #endregion

    #region void normales
    void Start()
    {
        Sanity = MaxSanity;
        sanitybar.startSanityBar(Sanity);
        //Debug.Log("Nivel de cordura: " + Sanity);
    }

    // Update is called once per frame
    void Update()
    {
        RecuperarSanidad();
        SacarSanidad();
    }
    #endregion

    #region code

    public void RecuperarSanidad()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((Sanity + SanityHealer) > MaxSanity)
            {
                Sanity = MaxSanity;
            }
            else
            {
                Sanity += SanityHealer;
            }
            sanitybar.SetSanity(Sanity);
            Debug.Log("El nuevo nivel de sanidad es:" + Sanity);
            //collision.gameObject.SetActive(false);
        }
    }
    public void SacarSanidad() //para testear la mecanica de la sanidad nom�s
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Sanity = Sanity - 2.0f;
            sanitybar.SetSanity(Sanity);
            Debug.Log("El nuevo nivel de sanidad es:" + Sanity);
            //collision.gameObject.SetActive(false);
        }
    }
    #endregion
}
