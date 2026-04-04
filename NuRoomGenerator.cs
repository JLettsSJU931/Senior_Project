using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    public TileBase wallTile;

    const int HEIGHT = 18;
    const int WIDTH = 32;

    public int dungeonWidth = 4;
    public int dungeonHeight = 4;

    int[,] map;
    int[,] fullMap;

    void Start()
    {
        GenerateDungeon();
        RenderFullMap();
    }


    // DUNGEON GENERATION


    class RoomData
    {
        public int[,] map;
        public bool up, down, left, right;
    }

    void GenerateDungeon()
    {
        int roomW = WIDTH;
        int roomH = HEIGHT;

        fullMap = new int[dungeonWidth * roomW, dungeonHeight * roomH];

        RoomData[,] rooms = new RoomData[dungeonWidth, dungeonHeight];

        for (int x = 0; x < dungeonWidth; x++)
        {
            for (int y = 0; y < dungeonHeight; y++)
            {
                bool needUp = (y > 0) && rooms[x, y - 1].down;
                bool needLeft = (x > 0) && rooms[x - 1, y].right;

                RoomData newRoom = GenerateRoom(needUp, needLeft);
                rooms[x, y] = newRoom;

                PasteRoom(newRoom.map, x * roomW, y * roomH);
            }
        }
    }

    RoomData GenerateRoom(bool requireUp, bool requireLeft)
    {
        RoomData room = new RoomData();

        room.up = requireUp || Random.value > 0.5f;
        room.left = requireLeft || Random.value > 0.5f;
        room.right = Random.value > 0.5f;
        room.down = Random.value > 0.5f;

        if (room.up && room.down && room.left && room.right)
            ArenaUDLR();
        else if (room.up && room.down)
            ArenaUD();
        else if (room.left && room.right)
            ArenaLR();
        else if (room.up)
            ArenaU();
        else if (room.down)
            ArenaD();
        else
            ArenaClosed();

        room.map = map;
        return room;
    }

    void PasteRoom(int[,] room, int startX, int startY)
    {
        for (int x = 0; x < room.GetLength(0); x++)
        {
            for (int y = 0; y < room.GetLength(1); y++)
            {
                fullMap[startX + x, startY + y] = room[x, y];
            }
        }
    }

    void RenderFullMap()
    {
        tilemap.ClearAllTiles();

        int width = fullMap.GetLength(0);
        int height = fullMap.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);

                if (fullMap[x, y] == 1)
                    tilemap.SetTile(pos, wallTile);
                else
                    tilemap.SetTile(pos, floorTile);
            }
        }
    }


    // ROOM LAYOUTS (unfini.)


    void ArenaClosed()
    {
        map = new int[WIDTH, HEIGHT];
        FillWalls();

        for (int x = 1; x < WIDTH - 1; x++)
            for (int y = 1; y < HEIGHT - 1; y++)
                map[x, y] = 0;
    }

    void ArenaU()
    {
        ArenaClosed();
        OpenTop();
    }

    void ArenaD()
    {
        ArenaClosed();
        OpenBottom();
    }

    void ArenaLR()
    {
        ArenaClosed();
        OpenLeft();
        OpenRight();
    }

    void ArenaUD()
    {
        ArenaClosed();
        OpenTop();
        OpenBottom();
    }

    void ArenaUDLR()
    {
        ArenaClosed();
        OpenTop();
        OpenBottom();
        OpenLeft();
        OpenRight();
    }


    // HELPERS (need to be redone after tweaking layouts)


    void FillWalls()
    {
        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;
    }

    void OpenTop()
    {
        for (int i = 14; i <= 17; i++)
            map[i, HEIGHT - 1] = 0;
    }

    void OpenBottom()
    {
        for (int i = 14; i <= 17; i++)
            map[i, 0] = 0;
    }

    void OpenLeft()
    {
        for (int i = 7; i <= 10; i++)
            map[0, i] = 0;
    }

    void OpenRight()
    {
        for (int i = 7; i <= 10; i++)
            map[WIDTH - 1, i] = 0;
    }
}