using UnityEngine;
using UnityEngine.AI;


public class EnemyAi : MonoBehaviour
{

    public Transform player; // refrence for player char.
    private Rigidbody2D rb; // rigidbody
    public float speed = 2f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized; // sets the direction 
            rb.linearVelocity = new Vector2(direction.x*speed, direction.y*speed); // velocity  
        }

    }

    void OnCollisonEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           //damage goes here, unless shooting
        }
    }
}
