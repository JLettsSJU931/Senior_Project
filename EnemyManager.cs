using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static int enemyCount = 0;
    //insert into enemy object start count ++, death method add count -- and then add spawnchest
    public static void SpawnChest(Vector3 position)
    {
        GameObject chest = new GameObject("Chest");
        chest.transform.position = position;

        SpriteRenderer sr = chest.AddComponent<SpriteRenderer>();
        sr.sprite = Resources.GetBuiltinResource<Sprite>("INSERT OBJECT FOR CHEST HERE UNFINISHED");

        BoxCollider2D col = chest.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        chest.AddComponent<Chest>();
    }
}