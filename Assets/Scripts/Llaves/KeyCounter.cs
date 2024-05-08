using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyCounter : MonoBehaviour
{
    private TextMeshProUGUI keysText;

    // Start is called before the first frame update
    void Start()
    {
        keysText = GetComponent<TextMeshProUGUI>();
    }

   public void UpdateKeyText(PlayerInventory playerInventory)
    {
        keysText.text = playerInventory.NumberKeys.ToString();

    }
}
