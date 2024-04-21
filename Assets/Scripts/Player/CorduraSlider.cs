using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorduraSlider : MonoBehaviour
{
    public Slider slider;

    #region code
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    //Para que el máximo del slider sea la cantidad de vida del pj
    public void SetMaxSanity(float corduraMax)
    {
        slider.maxValue = corduraMax;
        slider.value = corduraMax;
    }
    //Para ir actualizando la vida en el slider desde otros scripts
    public void SetSanity(float cordura)
    {
        slider.value = cordura;
    }
    //configura la vida desde el inicio del juego en otros scripts
    public void startSanityBar(float cordura)
    {
        SetMaxSanity(cordura);
        SetSanity(cordura);
    }
    //desactiva el slider
    public void Desactivar()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
