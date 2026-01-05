using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float rightBoundary = 5f;
    public float leftBoundary = -5f;
    private int direction = 1;
    public Collider2D detectionZone;

    void Update()
    {
        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        if(transform.position.x >= rightBoundary || transform.position.x <= leftBoundary)
        {
            direction *= -1;
        }
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         transform.position = Vector3.MoveTowards();
    //     }
    // }
}
