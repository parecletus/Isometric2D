using UnityEngine;
using SuperTiled2Unity;
using Unity.Mathematics;
using System;
public class TileManager : MonoBehaviour // works 
{
    /// <summary>
    /// Creates Tiles relative to their positions
    /// When Event is triggered :
    /// It checks if previous event is different from this one.
    /// If it is then it changes transparency to show tiles. 
    /// </summary>

    public SuperMap map;
    public GameObject Big_Tile; // 2x2 tile prfab
    public GameObject Small_Tile; // 1x1 tile prefab
    public GameObject Tiles_Holder;
    private SpriteRenderer[] sr_tiles;

    private bool previous_call;
    private static int xsize = 16;
    private static int ysize = 16;
    public static int[,] TileMap = new int[xsize, ysize];
    public static Vector2Int TilemapSize = new Vector2Int(xsize, ysize);

    void Start()
    {
        GlobalEvents<Vector2>.coordinates.AddListener(GridCoordinates);
        CreateTiles();
        sr_tiles = GetComponentsInChildren<SpriteRenderer>();
        GlobalEvents<bool>.tiles.AddListener(ShowTiles);
    }

    public void GridCoordinates(Vector2 coordinates)
    {
        Helper.GridCalculator(coordinates);
    }
    public void CreateTiles()
    {
        int[] orj_array = JsonReader_Map.GetArray(1);
        int[,] array = TileMap;


        int j = 0;
        for (int i = 0; i < orj_array.Length; i++)
        {
            array[i % 16, j] = orj_array[i];

            if (i % 16 == 0 && i != 0) j++;

            if (orj_array[i] == 3)
            {
                GameObject bro = Instantiate(Small_Tile, new Vector3(Grid_to_World(i, j).x, Grid_to_World(i, j).y, 0), quaternion.identity);

                bro.transform.parent = Tiles_Holder.transform; // tiles holder 
                bro.transform.name = "Coordinates: " + i % 16 + " , " + j;
            }
        }
        TileMap = array;
    }
    private Vector2 Grid_to_World(int x, int y)
    {
        // calculates grid coordinates to world point 
        Vector2 coor = Helper.PointCalculator(x % 16, y, map.m_TileWidth, map.m_TileHeight);
        Vector2 isometric = Helper.Isometric_Vector2(coor);

        float xn = MathF.Round(isometric.x, 3);
        float yn = MathF.Round(isometric.y, 3);
        return new Vector2(xn, yn);
    }
    public void ShowTiles(bool incoming_bool)
    {
        // Could use for loops or list<spriterenderer> instead of array to make it faster. 
        // There are not too many tiles. 
        bool IsCallDifferent = previous_call != incoming_bool ? true : false;

        if (IsCallDifferent)
        {
            if (incoming_bool)
            {
                foreach (SpriteRenderer sr in sr_tiles)
                {
                    sr.color = new Color(1f, 1f, 1f, 200 / 255f);
                }
            }
            else
            {
                foreach (SpriteRenderer sr in sr_tiles)
                {
                    sr.color = new Color(1f, 1f, 1f, 0 / 255f);
                }
            }
        }
        previous_call = incoming_bool;
    }

    void OnDestroy()
    {
        GlobalEvents<Vector2>.coordinates.RemoveListener(GridCoordinates);
        GlobalEvents<bool>.tiles.RemoveListener(ShowTiles);
    }
}
