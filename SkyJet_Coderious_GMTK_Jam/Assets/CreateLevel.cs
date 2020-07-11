using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CreateLevel : MonoBehaviour
{
    public Grid grid;
    public Tilemap map;
    public Tile[] floorTiles;
    public Tile wallTile, floorTile;

    public int width, height;

    Vector3Int pos;


    // Start is called before the first frame update
    void Start()
    {
        map.ClearAllTiles();
        pos = new Vector3Int(0, height / 2, 0);
        InitWalls();
        InitGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitWalls()
    {
        //draw upper and lower borders
        for (int i = -width / 2; i <= width / 2; i++)
        {
            map.SetTile(pos, wallTile);
            pos.y -= height;

            map.SetTile(pos, wallTile);
            pos.y += height;

            pos.x = i;
        }

        pos = new Vector3Int(-width / 2, height / 2 - 1, 0);

        //draw left and right borders
        for (int j = height / 2 - 1; j >= -height / 2 - 1; j--)
        {
            map.SetTile(pos, wallTile);
            pos.x += width - 1;

            map.SetTile(pos, wallTile);
            pos.x -= width - 1;

            pos.y = j;
        }
    }

    void InitGround()
    {
        for (int i = -width / 2 + 1; i <= width / 2 - 2; i++)
        {
            for (int j = height / 2 - 1; j >= -height / 2; j--)
            {
                if(Random.Range(0, 20) < 1)
                {
                    map.SetTile(new Vector3Int(i, j, 0), floorTiles[Random.Range(0, 21)]);
                }
                else
                {
                    map.SetTile(new Vector3Int(i, j, 0), floorTile);
                }
            }
        }
    }
}
