using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Health healthSystemTesting;

    // Start is called before the first frame update
    void Start()
    {
        healthSystemTesting = FindObjectOfType<Player>().HealthSystem;
    }

    public void Damage()
    {
        this.healthSystemTesting.TakeDamage(10);
        Debug.Log(this.healthSystemTesting.GetHealthPercentaje());

    }
    public void Heal()
    {
        this.healthSystemTesting.Heal(10);
        Debug.Log(this.healthSystemTesting.GetHealthPercentaje());
    }
}
