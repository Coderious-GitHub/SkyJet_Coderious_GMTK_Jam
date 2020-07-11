using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer backgroundRenderer;
    public Sprite[] backgrounds;

    int up, down, left, right;

    public float timeLeft = 30f;

    public TextMeshProUGUI uiTimeLeft;

    Vector2 movement;

    bool c, t, r, l;

    bool isPaused;

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
        c = false;
        t = false;
        r = false;
        l = false;

        isPaused = false;

        DefineMovement();
        backgroundRenderer.sprite = backgrounds[0];
        backgroundRenderer.size = new Vector2(1920, 1080);
    }



    // Update is called once per frame
    void Update()
    {
        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if(timeLeft < 0)
        {
            //Game Over
        }

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

        timeLeft -= Time.deltaTime;
        uiTimeLeft.text = timeLeft.ToString();

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

        while(down == up)
        {
            down = Random.Range(0, 26);
        }
        Debug.Log("Down: " + inputs[down]);

        left = Random.Range(0, 26);

        while (left == up || left == down)
        {
            left = Random.Range(0, 26);
        }

        Debug.Log("Left: " + inputs[left]);

        right = Random.Range(0, 26);

        while (right == up || right == down || right == left)
        {
            right = Random.Range(0, 26);
        }

        Debug.Log("Right: " + inputs[right]);


        if(inputs[up] == KeyCode.C || inputs[down] == KeyCode.C || inputs[left] == KeyCode.C || inputs[right] == KeyCode.C)
        {
            c = true;
            isPaused = true;
        }

        if (inputs[up] == KeyCode.T || inputs[down] == KeyCode.T || inputs[left] == KeyCode.T || inputs[right] == KeyCode.T)
        {
            t = true;
            isPaused = true;
        }

        if (inputs[up] == KeyCode.R || inputs[down] == KeyCode.R || inputs[left] == KeyCode.R || inputs[right] == KeyCode.R)
        {
            r = true;
            isPaused = true;
        }

        if (inputs[up] == KeyCode.L || inputs[down] == KeyCode.L || inputs[left] == KeyCode.L || inputs[right] == KeyCode.L)
        {
            l = true;
            isPaused = true;
        }
    }

}
