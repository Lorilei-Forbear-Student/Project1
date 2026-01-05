using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
[SerializeField] private int maxHealth = 100;
[SerializeField] private int damage;
[SerializeField] private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            currentHealth -= damage;
            if(currentHealth == 0)
            {
                GameOver();
            }
        }
    } 
    public void GameOver()
    {
            SceneManager.LoadScene("Game Over");
    }
}
