using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : HealthBar
{
    [SerializeField] private Slider slider;

    public override void SetUpLifeBar(Health hRef)
    {
        base.SetUpLifeBar(hRef);

        this.slider.maxValue = 1;
        this.slider.value = hRef.GetHealthPercentaje();
    }

    public override void OnHealthChanged()
    {
        this.slider.value = this.healthSys.GetHealthPercentaje();
    }
}
