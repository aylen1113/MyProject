using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory instance;
    public int NumberKeys { get; private set; }
    public int keysRequired = 5; 

    public UnityEvent<PlayerInventory> OnKeyCollected;

    public void KeyCollect()
    {
        NumberKeys++;
        OnKeyCollected.Invoke(this);
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
      
            CheckWinCondition();
        }
    }


public void CheckWinCondition()
    {
        if (NumberKeys == keysRequired)
        {
           
            Debug.Log("You win!");
            SceneManager.LoadScene("VictoryScreen");

        }
    }
}


