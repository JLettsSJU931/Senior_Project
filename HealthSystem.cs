using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
      

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0) { // death call
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died!"); // debug
        Destroy(gameObject); // death
        gameObject.SetActive(false); // disable
    }

    private void Damage()
    {
        currentHealth -= 100; // damage to obj
    }

}
