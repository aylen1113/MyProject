using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public KeyCode interactKey;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void FixedUpdate()
    {
        DeactiveScreen();
    }
    public void ActiveScreen()
    {
        gameObject.SetActive(true);
        //Time.timeScale = 0f;
        
    }

    public void DeactiveScreen()
    {
        if (Input.GetKeyDown(interactKey))
        {
            gameObject.SetActive(false);
            //Time.timeScale = 1f;
        }
    }
}
