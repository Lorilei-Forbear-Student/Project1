using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PlayerStats : MonoBehaviour
{
                //health vars
[SerializeField] public float maxHealth, damage, currentHealth;
[SerializeField] private PlayerStatUI healthBar;
                //stamina vars
[SerializeField] public float maxStamina, decreaseStamina, increaseStamina, currentStamina;
[SerializeField] private PlayerStatUI staminaBar;
                //movement vars
public PlayerMovement playerMovement;

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

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SetStamina(-decreaseStamina);
            playerMovement.speed = 10f;
        }
        else if(!Input.GetKey(KeyCode.LeftShift) && currentStamina < 100)
        {
            playerMovement.speed = 5f;
            SetStamina(increaseStamina);
        }
        else if(currentStamina == 0)
        {
            playerMovement.speed = 5f;
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
