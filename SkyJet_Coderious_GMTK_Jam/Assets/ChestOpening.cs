using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    public GameObject enemy;
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.isUnderControl = false;
        manager.upKey.text = "";
        manager.downKey.text = "";
        manager.leftKey.text = "";
        manager.rightKey.text = "";
        manager.attackKey.text = "";

        enemy.SetActive(true);
        gameObject.SetActive(false);
    }

}
