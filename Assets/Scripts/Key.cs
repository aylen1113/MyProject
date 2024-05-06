using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] AudioClip keySound;

    public void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.KeyCollect();
            Debug.Log("El " + other.name + " conseguió una llave!");

            if (other.CompareTag("Player"))
            {
                SoundController.instance.PlaySound(keySound);
                Debug.Log("Sonido reproducido correctamente");
            }

            gameObject.SetActive(false);

        }
    }
}

