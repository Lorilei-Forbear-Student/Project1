using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    [SerializeField] new public CircleCollider2D collider;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

IEnumerator StartAndStopAttack(float duration)
    {
            animator.SetBool("isAttacking", true);
            Debug.Log("button pressed");
        yield return new WaitForSeconds(duration);

        animator.SetBool("isAttacking", false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartAndStopAttack(0.5f));
        }
    }
}
