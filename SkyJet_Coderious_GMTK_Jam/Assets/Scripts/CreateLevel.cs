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

        //draw upper and lower borders
        for (int i = -width / 2; i <= width / 2; i++)
        {
            walls.SetTile(pos, wallTile);
            pos.y -= height;

            walls.SetTile(pos, wallTile);
            pos.y += height;

            pos.x = i;
        }

        pos = new Vector3Int(-width / 2, height / 2 - 1, 0);

        //draw left and right borders
        for (int j = height / 2 - 1; j >= -height / 2 - 1; j--)
        {
            walls.SetTile(pos, wallTile);
            pos.x += width - 1;

            walls.SetTile(pos, wallTile);
            pos.x -= width - 1;

            pos.y = j;
        }

        exitPos = FindExit();

        walls.SetTile(exitPos, null);
        exitMap.SetTile(exitPos, exitTile);
    }

    public void InitGround()
    {
        for (int i = -width / 2 + 1; i <= width / 2 - 2; i++)
        {
            for (int j = height / 2 - 1; j >= -height / 2; j--)
            {
                if(Random.Range(0, 30) < 3)
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

    Vector3Int FindExit()
    {
        int side = Random.Range(0, 4);

        //exit is North
        if(side == 0)
        {
            return new Vector3Int(Random.Range(-7, 7), 4, 0);
        }

        //exit is South
        if (side == 1)
        {
            return new Vector3Int(Random.Range(-7, 7), -5, 0);
        }

        //exit is East
        if (side == 2)
        {
            return new Vector3Int(-8, Random.Range(-4, 4), 0);
        }

        //exit is West
        if (side == 3)
        {
            return new Vector3Int(7, Random.Range(-4, 4), 0);
        }

        return new Vector3Int(0,0,0);
    }
}
