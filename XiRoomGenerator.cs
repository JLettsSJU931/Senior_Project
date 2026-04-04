using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

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

    bool[,,] connections; // [x,y,dir] (0=up,1=down,2=left,3=right)

    void Start()
    {
        GenerateDungeon();
        RenderFullMap();
    }

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

        GenerateDFSConnections();

        RoomData[,] rooms = new RoomData[dungeonWidth, dungeonHeight];

        for (int x = 0; x < dungeonWidth; x++)
        {
            for (int y = 0; y < dungeonHeight; y++)
            {
                RoomData room = GenerateRoomFromConnections(x, y);
                rooms[x, y] = room;

                PasteRoom(room.map, x * roomW, y * roomH);
            }
        }
    }

    // DFS SPANNING TREE (guarantees full connectivity)
    void GenerateDFSConnections()
    {
        connections = new bool[dungeonWidth, dungeonHeight, 4];
        bool[,] visited = new bool[dungeonWidth, dungeonHeight];

        Stack<Vector2Int> stack = new Stack<Vector2Int>();
        stack.Push(new Vector2Int(0, 0));
        visited[0, 0] = true;

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();
            List<int> dirs = new List<int>();

            if (current.y < dungeonHeight - 1 && !visited[current.x, current.y + 1]) dirs.Add(0); // up
            if (current.y > 0 && !visited[current.x, current.y - 1]) dirs.Add(1); // down
            if (current.x > 0 && !visited[current.x - 1, current.y]) dirs.Add(2); // left
            if (current.x < dungeonWidth - 1 && !visited[current.x + 1, current.y]) dirs.Add(3); // right

            if (dirs.Count == 0)
            {
                stack.Pop();
                continue;
            }

            int dir = dirs[Random.Range(0, dirs.Count)];

            int nx = current.x;
            int ny = current.y;

            if (dir == 0) ny++;
            if (dir == 1) ny--;
            if (dir == 2) nx--;
            if (dir == 3) nx++;

            // connect both directions
            connections[current.x, current.y, dir] = true;
            connections[nx, ny, Opposite(dir)] = true;

            visited[nx, ny] = true;
            stack.Push(new Vector2Int(nx, ny));
        }

        // ENSURE ≥3 openings per room
        for (int x = 0; x < dungeonWidth; x++)
        {
            for (int y = 0; y < dungeonHeight; y++)
            {
                int count = CountConnections(x, y);

                for (int dir = 0; dir < 4 && count < 3; dir++)
                {
                    int nx = x, ny = y;

                    if (dir == 0 && y < dungeonHeight - 1) ny++;
                    else if (dir == 1 && y > 0) ny--;
                    else if (dir == 2 && x > 0) nx--;
                    else if (dir == 3 && x < dungeonWidth - 1) nx++;
                    else continue;

                    if (!connections[x, y, dir])
                    {
                        connections[x, y, dir] = true;
                        connections[nx, ny, Opposite(dir)] = true;
                        count++;
                    }
                }
            }
        }
    }

    int Opposite(int dir)
    {
        if (dir == 0) return 1;
        if (dir == 1) return 0;
        if (dir == 2) return 3;
        return 2;
    }

    int CountConnections(int x, int y)
    {
        int c = 0;
        for (int i = 0; i < 4; i++)
            if (connections[x, y, i]) c++;
        return c;
    }

    RoomData GenerateRoomFromConnections(int x, int y)
    {
        RoomData room = new RoomData();

        room.up = connections[x, y, 0];
        room.down = connections[x, y, 1];
        room.left = connections[x, y, 2];
        room.right = connections[x, y, 3];

        // Layout selection
        if (room.up && room.down && room.left && room.right)
            ArenaUDLR();
        else
        {
            ArenaClosed();

            if (room.up) OpenTop();
            if (room.down) OpenBottom();
            if (room.left) OpenLeft();
            if (room.right) OpenRight();
        }

        room.map = map;
        return room;
    }

    void PasteRoom(int[,] room, int startX, int startY)
    {
        for (int x = 0; x < room.GetLength(0); x++)
            for (int y = 0; y < room.GetLength(1); y++)
                fullMap[startX + x, startY + y] = room[x, y];
    }

    void RenderFullMap()
    {
        tilemap.ClearAllTiles();

        int width = fullMap.GetLength(0);
        int height = fullMap.GetLength(1);

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                tilemap.SetTile(new Vector3Int(x, y, 0),
                    fullMap[x, y] == 1 ? wallTile : floorTile);
    }

    // ROOM LAYOUTS

    void ArenaClosed()
    {
        map = new int[WIDTH, HEIGHT];
        FillWalls();

        for (int x = 1; x < WIDTH - 1; x++)
            for (int y = 1; y < HEIGHT - 1; y++)
                map[x, y] = 0;
    }

    void ArenaUDLR() { ArenaClosed(); OpenTop(); OpenBottom(); OpenLeft(); OpenRight(); }

    // HELPERS

    void FillWalls()
    {
        for (int x = 0; x < WIDTH; x++)
            for (int y = 0; y < HEIGHT; y++)
                map[x, y] = 1;
    }

    void OpenTop() { for (int i = 14; i <= 17; i++) map[i, HEIGHT - 1] = 0; }
    void OpenBottom() { for (int i = 14; i <= 17; i++) map[i, 0] = 0; }
    void OpenLeft() { for (int i = 7; i <= 10; i++) map[0, i] = 0; }
    void OpenRight() { for (int i = 7; i <= 10; i++) map[WIDTH - 1, i] = 0; }
}