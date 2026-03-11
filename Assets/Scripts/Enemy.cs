using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int enemyMaxHealth, enemyCurrentHealth, enemyDamage;
    private SpriteRenderer spriteRenderer;
    public Color hitColor = Color.red;
    private Color originalColor;

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
            enemyCurrentHealth -= enemyDamage;
            
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
        yield return new WaitForSeconds(2);
        spriteRenderer.color = originalColor;
    }
}