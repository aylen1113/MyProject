using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject plushiePrefab;

    public PlayerHealth playerHealth;

    List<Health> plushies = new List<Health>();

    public void DrawPlushie()
    {
        ClearPlushies();

        float maxHealthReminder = playerHealth.maxHealth % 3;
        int plushiesToMake = (int)((playerHealth.maxHealth / 3) + maxHealthReminder);
        for(int i = 0; i < plushiesToMake; i++)
        {
            CreateEmptyPlushie();
        }

        for(int i = 0;i < plushies.Count; i++)
        {
            int plushieStatusRemainder = Mathf.Clamp(playerHealth.maxHealth - (i * 1), 0, 1);
            plushies[i].SetImage((HealthStatus)plushieStatusRemainder);
        }
}


    public void CreateEmptyPlushie()
    {
        GameObject newPlushie = Instantiate(plushiePrefab);
        newPlushie.transform.SetParent(transform);

        Health plushieComponent = newPlushie.GetComponent<Health>();
        plushieComponent.SetImage(HealthStatus.Empty);
        plushies.Add(plushieComponent);



    }

    public void ClearPlushies()
    {

        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);

        }
        plushies = new List<Health> ();

    }
}
