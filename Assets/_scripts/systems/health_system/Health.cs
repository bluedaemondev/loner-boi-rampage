using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    #region PROPERTIES
    private Action onHealthChanged;
    private Action onDamaged;
    private Action onHealed;
    private Action onDead;

    private float currentHealth;
    private float maxHealth;
    #endregion

    #region CONSTRUCTORS
    public Health(float max)
    {
        this.maxHealth = max;
        this.currentHealth = max;
    }
    #endregion

    #region BUILDER
    public Health SetMaxHealth(float newMax)
    {
        this.maxHealth = newMax;
        return this;
    }
    public Health SetCurrentHealth(float newCurrent)
    {
        this.currentHealth = newCurrent;
        return this;

    }
    public Health SetHealthChangedHandler(Action newHandler)
    {
        this.onHealthChanged = newHandler;
        return this;

    }
    public Health SetDamagedHandler(Action newHandler)
    {
        this.onDamaged = newHandler;
        return this;

    }
    public Health SetHealedHandler(Action newHandler)
    {
        this.onHealed = newHandler;

        return this;

    }
    public Health SetDeadHandler(Action newHandler)
    {
        this.onDead = newHandler;
        return this;

    }
    #endregion

    #region METHODS
    public float GetHealthPercentaje()
    {
        return currentHealth / maxHealth;
    }
    public void TakeDamage(float dmgAmount)
    {
        this.currentHealth -= dmgAmount;
        if (this.currentHealth < 0)
            this.currentHealth = 0;

        if (onHealthChanged != null)
            this.onHealthChanged();
        if (onDamaged != null)
            this.onDamaged();
    }
    public void Heal(float healAmount)
    {
        this.currentHealth += healAmount;
        if (this.currentHealth > this.maxHealth)
            this.currentHealth = maxHealth;

        if (onHealthChanged != null)
            this.onHealthChanged();
        if (onHealed != null)
            this.onHealed();
    }
    #endregion
}
