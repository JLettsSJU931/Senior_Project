using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    public TileBase wallTile;

    int[,] map;

    const int SIZE = 20;

    void Start()
    {
        ChooseRandomLayout();
        RenderMap();
    }

    void ChooseRandomLayout()
    {
        int choice = Random.Range(0, 5);

        if (choice == 0) Hallway();
        if (choice == 1) WindingHallway();
        if (choice == 2) Arena();
        if (choice == 3) Crossroads();
        if (choice == 4) PillarRoom();
    }

    void RenderMap()
    {
        tilemap.ClearAllTiles();

        int width = map.GetLength(0);
        int height = map.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                if (map[x, y] == 1)
                    tilemap.SetTile(pos, wallTile);
                else
                    tilemap.SetTile(pos, floorTile);
            }
        }
    }

    // Layout 1
    void Hallway()
    {
        map = new int[SIZE, SIZE];

        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
                map[x, y] = 1;

        for (int x = 0; x < SIZE; x++)
        {
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }

    // Layout 2
    void WindingHallway()
    {
        map = new int[SIZE, SIZE];

        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
                map[x, y] = 1;

        int yPos = 10;

        for (int x = 1; x < SIZE - 1; x++)
        {
            map[x, yPos] = 0;

            if (Random.value > 0.5f && yPos < SIZE - 2)
                yPos++;

            if (Random.value < 0.5f && yPos > 1)
                yPos--;
        }
    }

    // Layout 3
    void Arena()
    {
        map = new int[SIZE, SIZE];

        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
            {
                if (x == 0 || y == 0 || x == SIZE - 1 || y == SIZE - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
    }

    // Layout 4
    void Crossroads()
    {
        map = new int[SIZE, SIZE];

        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
                map[x, y] = 1;

        for (int i = 0; i < SIZE; i++)
        {
            map[9, i] = 0;
            map[10, i] = 0;
            map[i, 9] = 0;
            map[i, 10] = 0;
        }
    }

    // Layout 5
    void PillarRoom()
    {
        map = new int[SIZE, SIZE];

        for (int x = 0; x < SIZE; x++)
            for (int y = 0; y < SIZE; y++)
            {
                if (x == 0 || y == 0 || x == SIZE - 1 || y == SIZE - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;
        map[10, 10] = 1;
    }
}
/* To setup:
Right-click in the Hierarchy window and select 2D Object > Tilemap > Rectangular, this creates the tilemap.
Add the components Tilemap Collider 2D and Composite Collider 2D, this auto adds Rigid Body, set this to static.
Next, in the Project window, right-click the Assets folder and select Create > Folder to create a new folder, then name it some version of "Tiles" . Right-click the Tiles folder and select Create > 2D > Tile Palette > Rectangular, name this whatever, i just defaulted to "Game Palette"
In the tile folder, create 2 different sprite assets you want to use, one for floor, and one for walls. (I would for the time default to basic shapes, square triangle etc)
still in the tile folder, Create > 2D > Tiles > Auto tile, do this twice. name whtevr
In the inspector, set your floor tile's Tile Collider to None, and the wall to Grid. also set the sprite.
Back in Hierarchy, make a blank game object and attach this file, MapGenerator, to it (id name it something like MapManager), then set your tilemap, floor tile, and wall tile to the assets you made. 

*/