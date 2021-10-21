using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : HealthBar
{
    [SerializeField] private Slider slider;

    public override void Start()
    {
        //this.slider = transform.Find()
    }

    public override void SetUpLifeBar(Health hRef)
    {
        this.healthSys = hRef.SetHealthChangedHandler(this.OnHealthChanged);

        this.slider.maxValue = 1;
        this.slider.value = hRef.GetHealthPercentaje();
    }

    public override void OnHealthChanged()
    {
        Debug.Log("asd " + this.healthSys.GetHealthPercentaje());
        this.slider.value = this.healthSys.GetHealthPercentaje();
    }
}
