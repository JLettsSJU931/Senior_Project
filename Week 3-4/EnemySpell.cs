// James Letts Brennan Duff
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpell : MonoBehaviour
{
    private GameObject player; // refrence for player char.
    private Vector3 playerLoc;
    private Rigidbody2D rb;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        playerLoc = player.transform.position;
        Vector2 direction = playerLoc - transform.position;
        Vector2 rotation = transform.position - playerLoc;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
