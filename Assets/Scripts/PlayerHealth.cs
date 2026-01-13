using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
            //health variables
[SerializeField] private float maxHealth, damage, currentHealth;
[SerializeField] private PlayerStatUI healthBar;
            //stamina variables
[SerializeField] private float maxStamina, reduceStamina, increaseStamina, currentStamina;


    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("left shift pressed");

        }
    }

    public void SetHealth(float healthChange)
    {
        currentHealth += healthChange;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.SetHealth(currentHealth);
    }
    public void GameOver()
    {
            SceneManager.LoadScene("Game Over");
    }
}
