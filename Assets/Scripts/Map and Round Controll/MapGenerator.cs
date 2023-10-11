using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject mapTile;

    [SerializeField]private int mapWidth;
    [SerializeField]private int mapHeight;

    public static List<GameObject> MapTiles = new List<GameObject>();
    public static List<GameObject> PathTiles = new List<GameObject>();
    public static GameObject StartTile;
    public static GameObject EndTile;

    private bool reachedX = false;
    private bool reachedY = false;

    private GameObject currentTile;
    private int currentIndex;
    private int nextIndex;

    public Color pathColor;
    public Color startColor;
    public Color endColor;
    private void Start()
    {
        MapTiles = new List<GameObject>();
        PathTiles = new List<GameObject>();

        GenerateMap();
    }

    //private void Awake()
    //{
    //    GenerateMap();
    //}

    private List<GameObject> GetTopEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();
        for (int i = mapWidth*(mapHeight-1); i < mapWidth*mapHeight; i++)
        {
            edgeTiles.Add(MapTiles[i]);
        }
        return edgeTiles;
    }

    private List<GameObject> GetBottomEdgeTiles()
    {
        List<GameObject> edgeTiles = new List<GameObject>();
        for (int i = 0; i < mapWidth; i++)
        {
            edgeTiles.Add(MapTiles[i]);
        }
        return edgeTiles;
    }
    private void MoveDown()
    {
        PathTiles.Add(currentTile);
        currentIndex = MapTiles.IndexOf(currentTile);
        nextIndex = currentIndex-mapWidth;
        currentTile = MapTiles[nextIndex];
    }
    private void MoveLeft()
    {
        PathTiles.Add(currentTile);
        currentIndex = MapTiles.IndexOf(currentTile);
        nextIndex = currentIndex-1;
        currentTile = MapTiles[nextIndex];
    }
    private void MoveRight()
    {
        PathTiles.Add(currentTile);
        currentIndex = MapTiles.IndexOf(currentTile);
        nextIndex = currentIndex+1;
        currentTile = MapTiles[nextIndex];
    }

    private void GenerateMap()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                GameObject newTile = Instantiate(mapTile);
                MapTiles.Add(newTile);
                newTile.transform.position = new Vector2(x, y);
            }
        }

        List<GameObject> topEdgeTiles = GetTopEdgeTiles();
        List<GameObject> bottomEdgeTiles = GetBottomEdgeTiles();


        int rand1 = Random.Range(0, mapWidth);
        int rand2 = Random.Range(0, mapWidth);

        StartTile = topEdgeTiles[rand1];
        EndTile = bottomEdgeTiles[rand2];

        currentTile = StartTile;
        MoveDown();
        int loopCount = 0;
        while (!reachedX)
        {
            loopCount++;
            if (loopCount > 100)
            {
                Debug.Log("Loop ran too long! Broke out of it!");
                break;
            }
            if (currentTile.transform.position.x > EndTile.transform.position.x)
            {
                MoveLeft();
            }
            else if (currentTile.transform.position.x < EndTile.transform.position.x)
            {
                MoveRight();
            }
            else
            {
                reachedX = true;
            }
        }

        while(!reachedY)
        {
            if (currentTile.transform.position.y > EndTile.transform.position.y)
                MoveDown();
            else
                reachedY = true;
        }

        PathTiles.Add(EndTile);

        foreach (GameObject tile in PathTiles)
        {
            tile.GetComponent<SpriteRenderer>().color = pathColor;
        }

        StartTile.GetComponent<SpriteRenderer>().color = startColor;
        EndTile.GetComponent<SpriteRenderer>().color = endColor;
    }

}
