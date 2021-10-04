using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    protected Health healthSys;

    protected Transform lifeBarFill;

    public void Start()
    {
        this.lifeBarFill = transform.Find("Bar");
        
    }

    public virtual void SetUpLifeBar(Health hRef)
    {
        this.healthSys = hRef.SetHealthChangedHandler(this.OnHealthChanged);
    }
    public virtual void OnHealthChanged()
    {
        this.lifeBarFill.localScale = new Vector3(this.healthSys.GetHealthPercentaje(), 1);
    }
}
