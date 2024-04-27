using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {
        //l�gica para los botones usados dentro del juego
        public void Restart()
        {
            SceneManager.LoadScene("Game");
            Time.timeScale = 1f;
        }
        public void Menu()
        {
            SceneManager.LoadScene("Men�");
        }
        public void PlayButton()
        {
            SceneManager.LoadScene("Game");
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
