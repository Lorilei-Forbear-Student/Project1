using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

      void Update()
    {
        EnemyFlip();
        lastPosition = transform.position;
    }
    public void EnemyFlip()
    {
        if(transform.position.x > lastPosition.x || transform.position.x < lastPosition.x)
        {
            transform.Rotate(0.0f, -180.0f, 0.0f);
        }
    }
    
}
