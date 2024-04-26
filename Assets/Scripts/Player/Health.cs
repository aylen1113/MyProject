using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour

{
    public Sprite full, empty;
    Image plushieImage;


    private void Awake()
    {
       plushieImage = GetComponent<Image>();
    }
    public void SetImage(HealthStatus status)
    {
        switch (status) {

            case HealthStatus.Empty:
            plushieImage.sprite = empty;
            break;

            case HealthStatus.Full:
            plushieImage.sprite = full;
            break;




        }
    }
}
public enum HealthStatus
{
    Empty = 0,
    Full = 1,
}

