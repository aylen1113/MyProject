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
            Candado candado = FindObjectOfType<Candado>();
            if (candado != null)
            {
                candado.AddKey();
            }


            gameObject.SetActive(false);

        }
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
}

