using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMouse : MonoBehaviour
{
    public AudioSource Audio;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }

    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Audio.Play();
        }
    }
}
