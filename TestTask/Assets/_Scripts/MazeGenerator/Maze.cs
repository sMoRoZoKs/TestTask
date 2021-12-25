using UnityEngine;

public class Maze
{
    public MazeGeneratorCell[,] cells;
    public Vector2Int finishPosition;
    public Vector2Int endPosition;
    public Vector2Int[,] deadZones;
}

public class MazeGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
    public int DistanceFromStart;
}
