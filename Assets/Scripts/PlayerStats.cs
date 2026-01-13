using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
                //health vars
[SerializeField] private float maxHealth, damage, currentHealth;
[SerializeField] private PlayerStatUI healthBar;
                //stamina vars
[SerializeField] private float maxStamina, decreaseStamina, increaseStamina, currentStamina;
[SerializeField] private PlayerStatUI staminaBar;

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
        staminaBar.SetMaxStamina(maxStamina);
        currentStamina = maxStamina;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            SetHealth(-damage);
            if(currentHealth == 0)
            {
                GameOver();
            }
        }
    } 

    public void SetHealth(float healthChange)
    {
        currentHealth += healthChange;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.SetHealth(currentHealth);
    }

    public void SetStamina(float staminaChange)
    {
        currentStamina += staminaChange;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        staminaBar.SetStamina(currentStamina);
    }
    public void GameOver()
    {
            SceneManager.LoadScene("Game Over");
    }
}
