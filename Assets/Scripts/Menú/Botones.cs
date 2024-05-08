using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
        }
        
        //lógica para los botones usados dentro del juego
        public void Restart()
        {
            SceneManager.LoadScene("Game 1");
            Time.timeScale = 1f;
        }
        public void Menu()
        {
            SceneManager.LoadScene("Menú");
        }
        public void PlayButton()
        {
            SceneManager.LoadScene("Game 1");
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
