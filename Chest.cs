using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool opened = false;

    private void OnTriggerEnter2D(Collider2D other) // add collider to player
    {
        if (opened) return;

        if (other.CompareTag("Player"))
        {
            open();
        }
    }

    void open()
    {
        opened = true;

        //reward goes here

        Destroy(gameObject);
    }
}
