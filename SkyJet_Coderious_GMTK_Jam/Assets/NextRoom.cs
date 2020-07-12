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
        levelCreator.enterPos = new Vector3Int(levelCreator.exitPos.x, -levelCreator.exitPos.y - 1, 0);
        
        levelCreator.InitWalls();
        levelCreator.InitGround();

        levelCreator.walls.SetTile(levelCreator.enterPos, null);
        playerRb.position = new Vector2(levelCreator.enterPos.x, levelCreator.enterPos.y + 1);

        hasEnterNewRoom = true;

    }

}
