using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Health healthSys;

    private Transform lifeBarFill;

    public void Start()
    {
        this.lifeBarFill = transform.Find("Bar");
    }

    public void SetUpLifeBar(Health hRef)
    {
        this.healthSys = hRef;
        this.healthSys.SetHealthChangedHandler(this.OnHealthChanged);
    }
    public void OnHealthChanged()
    {
        this.lifeBarFill.localScale = new Vector3(this.healthSys.GetHealthPercentaje(), 1);
    }
}
