using UnityEngine;
using System.Collections;

public class EnemyAIMelee : MonoBehaviour
{
    private enum State
    {
        Idle, Chasing, Attacking, Rest
    }
    private State currentState;
    public GameObject player; // refrence for player char.
    private Transform playerLoc;
    private Rigidbody2D rb; // rigidbody
    private bool canAttack = true;

    public float speed = 2f;
    public float detectionRadius = 10f;
    public float attackRange = 1f;
    public float attackCooldown = 2f;
    public GameObject attackHitbox;
    private BoxCollider2D hitboxCollider;
    private Transform hitboxLoc;
    private Transform hitboxPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = State.Idle;
        playerLoc = player.transform;
        hitboxCollider = attackHitbox.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
        switch (currentState)
        {
            case State.Idle:
                IdleBehavior();
                break;
            case State.Chasing:
                ChasingBehavior();
                break;
            case State.Attacking:
                AttackingBehavior();
                break;
            case State.Rest:
                RestBehavior();
                break;
        }

    }
    void IdleBehavior()
    {
        if (Vector2.Distance(transform.position, playerLoc.position) < detectionRadius)
        {
            currentState = State.Chasing;
        }
        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
    }
    void ChasingBehavior()
    {
        Vector2 direction = (playerLoc.position - transform.position).normalized; // sets the direction 
        rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed); // velocity  
        if (Vector2.Distance(transform.position, playerLoc.position) < attackRange)
        {
            
            currentState = State.Attacking;
        }
        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
    }
    void AttackingBehavior()
    {
        rb.linearVelocity = Vector2.zero;
        if (canAttack == true)
        {
            StartCoroutine(Attack());
        }
        if (Vector2.Distance(transform.position, playerLoc.position) > attackRange)
        {
            currentState = State.Chasing;
        }
    }
    IEnumerator Attack()
    {
        if (playerLoc.position.x > transform.position.x + 0.5f)
        {
            attackHitbox.transform.localPosition = new Vector2(1f, 0f);
        }
        if (playerLoc.position.x < transform.position.x - 0.5f)
        {
            attackHitbox.transform.localPosition = new Vector2(-1f, 0f);
        }
        if (playerLoc.position.y > transform.position.y + 0.5f)
        {
            attackHitbox.transform.localPosition = new Vector2(0f, 1f);
        }
        if (playerLoc.position.y < transform.position.y - 0.5f)
        {
            attackHitbox.transform.localPosition = new Vector2(0f, -1f);
        }
        canAttack = false;
        // Trigger attack animation or activate hitbox
        attackHitbox.SetActive(true); // Enable the hitbox
        hitboxCollider.enabled = true; // Enable the hitbox collider
        // Wait for a short duration matching the attack animation time
        yield return new WaitForSeconds(0.2f); // Adjust as needed
        hitboxCollider.enabled = false; // Disable the hitbox collider
        attackHitbox.SetActive(false); // Disable the hitbox
        // Wait for cooldown
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;

    }
    void RestBehavior()
    {
        rb.linearVelocity = Vector2.zero;
    }
        void OnCollisonEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //damage goes here, unless shooting
        }
    }
}
