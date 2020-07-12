using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Pathfinding;

public class CreateLevel : MonoBehaviour
{
    public Grid grid;
    public Tilemap walls, walkableGround, obstacleGround, enterMap, exitMap;
    public Tile[] floorTiles;
    public Tile wallTile, floorTile, exitTile;

    public Vector3Int enterPos, exitPos;

    public int width, height;

    // Start is called before the first frame update
    void Start()
    {
        walls.ClearAllTiles();
        InitWalls();
        InitGround();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void InitWalls()
    {
        Vector3Int pos = new Vector3Int(0, height / 2, 0);
        Vector3Int exit = new Vector3Int(0, 0, 0);
        bool exitPlaced = false;

        //draw upper and lower borders
        for (int i = -width / 2; i <= width / 2; i++)
        {
            Debug.Log(pos);
            walls.SetTile(pos, wallTile);
            pos.y -= height;

            Debug.Log(pos);
            walls.SetTile(pos, wallTile);
            pos.y += height;

            pos.x = i;

            if (!exitPlaced && Random.Range(0, 50) < 5 && i != -width / 2 && i != width / 2)
            {
                exit = pos;
                exitPlaced = true;
            }
        }

        pos = new Vector3Int(-width / 2, height / 2 - 1, 0);

        //draw left and right borders
        for (int j = height / 2 - 1; j >= -height / 2 - 1; j--)
        {
            Debug.Log(pos);
            walls.SetTile(pos, wallTile);
            pos.x += width - 1;

            Debug.Log(pos);
            walls.SetTile(pos, wallTile);
            pos.x -= width - 1;

            pos.y = j;

            if (!exitPlaced && Random.Range(0, 50) < 5 && j != height / 2 - 1 && j != -height / 2 - 1)
            {
                exit = pos;
                exitPlaced = true;
            }
        }

        exitPos = exit;

        walls.SetTile(exit, null);
        exitMap.SetTile(exit, exitTile);
        exitPlaced = false;
    }

    public void InitGround()
    {
        for (int i = -width / 2 + 1; i <= width / 2 - 2; i++)
        {
            for (int j = height / 2 - 1; j >= -height / 2; j--)
            {
                if(Random.Range(0, 30) < 2)
                {
                    walkableGround.SetTile(new Vector3Int(i, j, 0), floorTiles[Random.Range(0, floorTiles.Length)]);
                }
                else
                {
                    walkableGround.SetTile(new Vector3Int(i, j, 0), floorTile);
                }
            }
        }
    }
}
