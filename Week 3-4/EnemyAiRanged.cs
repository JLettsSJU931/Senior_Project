using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiRanged : MonoBehaviour
{
    private enum State
    {
        Idle, Moving, Shooting, Rest
    }
    private State currentState;
    public GameObject player; // refrence for player char.
    private Transform playerLoc;
    private Rigidbody2D rb; // rigidbody
    private bool canShoot = true;

    public float speed = 5f;
    public float shootRange = 10f;
    public float personalSpace = 3f;
    public GameObject spell;
    public GameObject rotatePoint;
    public Transform spellTransform;
    public bool castable;
    private float timer;
    public float castTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = State.Idle;
        playerLoc = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
        else
        {
            Vector2 rotation = playerLoc.position - transform.position;

            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            rotatePoint.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
            switch (currentState)
            {
                case State.Idle:
                    IdleBehavior();
                    break;
                case State.Moving:
                    MovingBehavior();
                    break;
                case State.Shooting:
                    ShootingBehavior();
                    break;
                case State.Rest:
                    RestBehavior();
                    break;
            }
    }
    void IdleBehavior()
    {
        if (Vector2.Distance(transform.position, playerLoc.position) <= shootRange)
        {
            currentState = State.Shooting;
        }
        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
    }
    void MovingBehavior()
    {
        Vector2 direction = -(playerLoc.position - transform.position).normalized; // sets the direction 
        rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed); // velocity  
        if (Vector2.Distance(transform.position, playerLoc.position) >= shootRange - 5f)
        {
            currentState = State.Shooting;
        }
        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
    }
    void ShootingBehavior()
    {
        rb.linearVelocity = Vector2.zero;
        if (canShoot == true)
        {
            StartCoroutine(Shoot());
        }
        if (playerLoc == null)
        {
            currentState = State.Rest;
        }
    }
    IEnumerator Shoot()
    {
        if (Vector2.Distance(transform.position, playerLoc.position) <= personalSpace)
        {
            currentState = State.Moving;
        }
        canShoot = false;
        Instantiate(spell, spellTransform.position, Quaternion.identity);
        yield return new WaitForSeconds(castTime);
        canShoot = true;
    }
    void RestBehavior()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
