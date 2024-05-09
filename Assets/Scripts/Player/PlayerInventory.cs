using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    [Header("LLaves")]
    public static PlayerInventory instance;
    public int NumberKeys { get; private set; }
    public int keysRequired = 5; 

    public UnityEvent<PlayerInventory> OnKeyCollected;

    [Header("UI Dialogo")]
    public Panel Panel;

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

        if (other.CompareTag("ZonaPuerta") && NumberKeys < keysRequired)
        {
            Panel.ActiveScreen();
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


