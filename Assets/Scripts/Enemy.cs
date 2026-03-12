using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        if (collision.CompareTag("Player"))
        {
            enemyCurrentHealth -= enemyDamage;
            Flash();
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
}