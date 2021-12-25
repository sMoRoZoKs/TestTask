using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public Cell CellPrefab;
    public Vector3 CellSize = new Vector3(1,1,0);
    public HintRenderer HintRenderer;
    
    public Maze maze;
    [SerializeField] private GameObject greenZonePrefab;
    [SerializeField] private GameObject deadZonePrefab;

    [SerializeField] private int countDeadZone;
    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);

            }
        }
        SpawnDeadZones();
        Instantiate(greenZonePrefab, new Vector3(maze.finishPosition.x * CellSize.x, maze.finishPosition.y * CellSize.y, maze.finishPosition.y * CellSize.z), Quaternion.identity);
        HintRenderer.DrawPath();
    }
    private void SpawnDeadZones()
    {
        for (int i = 0; i < countDeadZone; i++)
        {
            int x = Random.Range(0, maze.cells.GetLength(0) - 1), y = Random.Range(0, maze.cells.GetLength(1) - 1); ;
            while (x % 2 != 0 || x == 0 || y == maze.cells.GetLength(0) - 1)
            {
                x = Random.Range(0, maze.cells.GetLength(0) - 1);
            }
            while (y % 2 != 0 || y == 0 || y == maze.cells.GetLength(1) - 1)
            {
                y = Random.Range(0, maze.cells.GetLength(1) - 1);
            }
            Instantiate(deadZonePrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);
        }
    }
}