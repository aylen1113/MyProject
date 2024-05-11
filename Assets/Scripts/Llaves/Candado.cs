using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candado : MonoBehaviour

{
    private int keysCollected = 0;
    public GameObject candado;

    public void AddKey()
    {
        keysCollected++;
        if (keysCollected >= 10)
        {
            if (candado != null)
            {
                candado.SetActive(false);
                Debug.Log("El candado desaparecio");
            }
            
        }
    }
}

