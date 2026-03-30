using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    public TileBase wallTile;

    int[,] map;

    const int HEIGHT = 18;
    const int WIDTH = 32;

    void Start()
    {
        ChooseRandomLayout();
        RenderMap();
    }

    void ChooseRandomLayout()
    {
        int choice = Random.Range(0, 0);

        if (choice == 0) HallwayDL();
        if (choice == 1) ArenaUDLR();
        if (choice == 2) CrossroadsUDL();
        if (choice == 3) PillarRoomUDLR();
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
    void HallwayUD()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 0; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
    }
    void HallwayUL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 7; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 0; x < 18; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void HallwayUR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;
        for (int y = 7; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 14; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void HallwayDL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 0; y < 11; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 0; x < 18; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void HallwayDR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;
        for (int y = 0; y < 11; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 14; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void HallwayLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int x = 0; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }

    // Layout 2
    /*void WindingHallway()
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
    }*/

    // Layout 3
    // ORDER OF DIRECTIONS IN FUNCTION TITLE ALWAYS ABIDES BY THE ORDER UP DOWN LEFT RIGHT
    void ArenaClosed()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
    }
    // DOOR UP
    void ArenaU()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
    }
    // DOOR DOWN
    void ArenaD()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
    }
    // DOOR LEFT
    void ArenaL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
    }
    // DOOR RIGHT
    void ArenaR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
    }
    // DOORS UP DOWN
    void ArenaUD()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;

    }
    // DOORS UP LEFT
    void ArenaUL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;

    }
    // DOORS UP RIGHT
    void ArenaUR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;

    }
    // DOORS DOWN LEFT
    void ArenaDL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
    }
    // DOORS DOWN RIGHT
    void ArenaDR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;

    }
    // DOORS LEFT RIGHT
    void ArenaLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
    }
    // DOOR UP DOWN LEFT
    void ArenaUDL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;

    }
    // DOORS UP DOWN RIGHT
    void ArenaUDR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;

    }
    // DOORS UP LEFT RIGHT
    void ArenaULR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
    }
    // DOORS DOWN LEFT RIGHT
    void ArenaDLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
    }
    // DOORS UP DOWN LEFT RIGHT
    void ArenaUDLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
    }
    // Layout 4
    void CrossroadsUDL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 0; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 14; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void CrossroadsUDR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 0; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 0; x < 17; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void CrossroadsULR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 7; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 0; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void CrossroadsDLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 0; y < 10; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 0; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }
    void CrossroadsUDLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;

        for (int y = 0; y < HEIGHT; y++)
        {
            map[14, y] = 0;
            map[15, y] = 0;
            map[16, y] = 0;
            map[17, y] = 0;
        }
        for (int x = 0; x < WIDTH; x++)
        {
            map[x, 7] = 0;
            map[x, 8] = 0;
            map[x, 9] = 0;
            map[x, 10] = 0;
        }
    }

    // Layout 5
    void PillarRoom()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;
    }
    void PillarRoomU()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
    }
    // DOOR DOWN
    void PillarRoomD()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
    }
    // DOOR LEFT
    void PillarRoomL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
    }
    // DOOR RIGHT
    void PillarRoomR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
    }
    // DOORS UP DOWN
    void PillarRoomUD()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;

    }
    // DOORS UP LEFT
    void PillarRoomUL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;

    }
    // DOORS UP RIGHT
    void PillarRoomUR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;

    }
    // DOORS DOWN LEFT
    void PillarRoomDL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
    }
    // DOORS DOWN RIGHT
    void PillarRoomDR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;

    }
    // DOORS LEFT RIGHT
    void PillarRoomLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
    }
    // DOOR UP DOWN LEFT
    void PillarRoomUDL()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;

    }
    // DOORS UP DOWN RIGHT
    void PillarRoomUDR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;

    }
    // DOORS UP LEFT RIGHT
    void PillarRoomULR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
    }
    // DOORS DOWN LEFT RIGHT
    void PillarRoomDLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
    }
    // DOORS UP DOWN LEFT RIGHT
    void PillarRoomUDLR()
    {
        map = new int[WIDTH, HEIGHT];

        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
            {
                if (x == 0 || y == 0 || x == WIDTH - 1 || y == HEIGHT - 1)
                    map[x, y] = 1;
                else
                    map[x, y] = 0;
            }

        map[5, 5] = 1;
        map[5, 14] = 1;
        map[14, 5] = 1;
        map[14, 14] = 1;

        map[0, 7] = 0;
        map[0, 8] = 0;
        map[0, 9] = 0;
        map[0, 10] = 0;
        map[WIDTH - 1, 7] = 0;
        map[WIDTH - 1, 8] = 0;
        map[WIDTH - 1, 9] = 0;
        map[WIDTH - 1, 10] = 0;
        map[14, HEIGHT - 1] = 0;
        map[15, HEIGHT - 1] = 0;
        map[16, HEIGHT - 1] = 0;
        map[17, HEIGHT - 1] = 0;
        map[14, 0] = 0;
        map[15, 0] = 0;
        map[16, 0] = 0;
        map[17, 0] = 0;
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
