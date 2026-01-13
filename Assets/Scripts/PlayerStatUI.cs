using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUI : MonoBehaviour
{
                //health vars
    public float Health, MaxHealth, HealthWidth, HealthHeight;
    [SerializeField] private RectTransform healthBar;
                //stamina vars
    public float Stamina, MaxStamina, StaminaWidth, StaminaHeight;
    [SerializeField] private RectTransform staminaBar;

    public void SetMaxHealth(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    public void SetMaxStamina(float maxStamina)
    {
        MaxStamina = maxStamina;
    }

    public void SetHealth(float health)
    {
        Health = health;
        float newHealthHeight = (Health / MaxHealth) * HealthHeight;

        healthBar.sizeDelta = new Vector2(HealthWidth, newHealthHeight);
    }

    public void SetStamina(float stamina)
    {
        Stamina = stamina;
        float newStaminaHeight = (Stamina / MaxStamina) * StaminaHeight;

        staminaBar.sizeDelta = new Vector2(StaminaWidth, newStaminaHeight);
    }
}
