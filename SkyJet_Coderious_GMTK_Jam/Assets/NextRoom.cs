using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextRoom : MonoBehaviour
{
    CreateLevel levelCreator;
    GameManager manager;
    public Rigidbody2D playerRb;

    bool hasEnterNewRoom = false;

    private void Start()
    {
        levelCreator = FindObjectOfType<CreateLevel>();
        manager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 offset = new Vector2(0, 0);

        if(levelCreator.exitPos.y == 4)
        {
            levelCreator.enterPos = new Vector3Int(levelCreator.exitPos.x, -5, 0);
            offset = new Vector2(0, 1);
        }

        if (levelCreator.exitPos.y == -5)
        {
            levelCreator.enterPos = new Vector3Int(levelCreator.exitPos.x, 4, 0);
            offset = new Vector2(0, -1);
        }

        if (levelCreator.exitPos.x == -8)
        {
            levelCreator.enterPos = new Vector3Int(7, levelCreator.exitPos.y, 0);
            offset = new Vector2(-1, 0);
        }

        if (levelCreator.exitPos.x == 7)
        {
            levelCreator.enterPos = new Vector3Int(-8, levelCreator.exitPos.y, 0);
            offset = new Vector2(1, 0);
        }


        levelCreator.InitWalls();
        levelCreator.InitGround();

        levelCreator.walls.SetTile(levelCreator.enterPos, null);
        playerRb.position = new Vector2(levelCreator.enterPos.x, levelCreator.enterPos.y) + offset;

        hasEnterNewRoom = true;

    }

}
