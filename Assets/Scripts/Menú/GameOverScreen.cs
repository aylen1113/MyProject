using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public GameObject gameOverPanel;

    private void Start()
    {
   
        gameOverPanel.SetActive(false);
    }

    public void ActiveScreen()
    {
    
        gameOverPanel.SetActive(true);



    }


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");

    }


}