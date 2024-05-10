using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public Image[] images;
 

    private int currentImageIndex = 0;

    void Start()
    {
        UpdateImage();
       
    }

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextImage();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SkipCutscene();
        }
    }

    void NextImage()
    {
        currentImageIndex++;
        UpdateImage();
    }

    void SkipCutscene()
    {
        SceneManager.LoadScene(3);
    }

    void UpdateImage()
    {
        if (currentImageIndex < images.Length)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (i == currentImageIndex)
                    images[i].gameObject.SetActive(true);
                else
                    images[i].gameObject.SetActive(false);
            }
        }
        else
        {
            
            SkipCutscene();
        }
    }
}
