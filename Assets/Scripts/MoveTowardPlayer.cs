using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class MoveTowardPlayer : MonoBehaviour
{
    private float moveSpeed = 2f;
    [SerializeField]private Transform playerTarget;
    private bool isPlayerDetected = false;

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
        if(isPlayerDetected == true && playerTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * Time.deltaTime);
        }
    }
}
