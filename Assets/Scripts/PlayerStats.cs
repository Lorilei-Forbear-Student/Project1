using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
                //health vars
[SerializeField] public float maxHealth, damage, currentHealth;
[SerializeField] private PlayerStatUI healthBar;
                //stamina vars
[SerializeField] public float maxStamina, decreaseStamina, increaseStamina, currentStamina;
public bool zeroed = false;
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
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0 && zeroed == false) //if holding shift, stamina decreases and you go faster. 
        {                                                                             //BUT, only if stamina has not been zeroed. (creates delay)
            SetStamina(-decreaseStamina);
            playerMovement.speed = 10f;
            if(currentStamina == 0) playerMovement.speed = 5f;
        }
        else if(!Input.GetKey(KeyCode.LeftShift) && currentStamina < 100) //if not holding shift, stamina regens until it hits 100
        {
            if(zeroed == true)
            {
                SetStamina(0.02f);
                playerMovement.speed = 3.5f;
                if(currentStamina == 100)
                {
                    zeroed = false;
                    playerMovement.speed = 5f;
                }
            }
            else
            {
                SetStamina(increaseStamina);
                playerMovement.speed = 5f;
            }
            
        }
        else if(currentStamina == 0)
        {
            zeroed = true;
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
