using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float enemyMaxHealth, enemyCurrentHealth, enemyDamage;
    private SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red;
    private Color originalColor;
    public PlayerStats player;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
        enemyCurrentHealth = enemyMaxHealth;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
        {
            enemyCurrentHealth -= enemyDamage / 2; //divided by 2 because the damage stays for too many frames, making the enemy die more quickly than anticipated,
            Flash();                               //and i don't want to fix it where it's broken.  #goated

            Die();
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.SetHealth(-player.damage);
            if(player.currentHealth == 0)
            {
                player.GameOver();
            }
        }
    } 
    public void Flash()
    {
        StopCoroutine(FlashRoutine());
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(0.4f);
        spriteRenderer.color = originalColor;
    }

    public void Die()
    {
        if(transform.parent.gameObject != null && enemyCurrentHealth == 0)
        {
            Destroy(transform.parent.gameObject);
        }
        else if(transform.parent.gameObject == null && enemyCurrentHealth == 0)
        {
            Destroy(this.gameObject);
        }

        //later, drop mechanic?
    }
}