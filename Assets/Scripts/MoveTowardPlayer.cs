using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    private float moveSpeed = 3f;
    [SerializeField]private Transform playerTarget;
    private bool isPlayerDetected = false;
    private bool enemyFacingRight = true;
    private float enemyHorizontal;
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerDetected = true;
            Debug.Log("Player detected");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerDetected = false;
        Debug.Log("Player outside detection zone");
    }
    void Update()
    {
        if(isPlayerDetected == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
        }

    }
 
    // private void EnemyFlip()
    // {
    //     if(enemyFacingRight &&  enemyHorizontal < 0f || !enemyFacingRight &&  enemyHorizontal > 0f)
    //     {
    //         enemyFacingRight = !enemyFacingRight;

    //         transform.Rotate(0.0f, -180f, 0.0f);
    //     }
    // }
}
