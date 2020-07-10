using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgrounds;

    int up, down, left, right;



    Vector2 movement;

    KeyCode[] inputs = new KeyCode[26] {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D,
        KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H,
        KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
        KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P,
        KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
        KeyCode.Y, KeyCode.Z
    };

    float movementSpeed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        DefineMovement();
        backgroundRenderer.sprite = backgrounds[0];
        backgroundRenderer.size = new Vector2(1920, 1080);

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(inputs[up]))
        {
            movement.y = movementSpeed;
        }

        if (Input.GetKeyDown(inputs[down]))
        {
            movement.y = -movementSpeed;
        }

        if (Input.GetKeyDown(inputs[left]))
        {
            movement.x = -movementSpeed;
        }

        if (Input.GetKeyDown(inputs[right]))
        {
            movement.x = movementSpeed;
        }

        if (!Input.anyKey)
        {
            movement = Vector2.zero;
        }

    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * Time.fixedDeltaTime);
    }

    void MovePlayer()
    {



    }

    void DefineMovement()
    {
        up = Random.Range(0, 26);
        Debug.Log("Up: " + inputs[up]);
        down = Random.Range(0, 26);
        Debug.Log("Down: " + inputs[down]);
        left = Random.Range(0, 26);
        Debug.Log("Left: " + inputs[left]);
        right = Random.Range(0, 26);
        Debug.Log("Right: " + inputs[right]);
    }

}
