using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Light2D playerLight;

    public GameObject commandPanel;

    int up, down, left, right, attack;

    public float timeLeft = 30f;

    public TextMeshProUGUI uiTimeLeft;

    Vector2 movement;

    bool c, t, r, l;
    public bool upAssigned, downAssigned, leftAssigned, rightAssigned, attackAssigned;
    public KeyCode upCommand, downCommand, leftCommand, rightCommand, attackCommand;

    public TextMeshProUGUI upKey, downKey, leftKey, rightKey, attackKey;

    public Light2D[] lights = new Light2D[4];

    public AnimationCurve curve;

    bool isScanned;

    KeyCode[] inputs = new KeyCode[26] {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D,
        KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H,
        KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L,
        KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P,
        KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X,
        KeyCode.Y, KeyCode.Z,
    };

    public float movementSpeed = 2f;
    public float xSpeed, ySpeed;
    public bool hasAttacked = false;

    // Start is called before the first frame update
    void Start()
    {
        c = false;
        t = false;
        r = false;
        l = false;

        upAssigned = false;
        downAssigned = false;
        leftAssigned = false;
        rightAssigned = false;
        attackAssigned = false;

        commandPanel.SetActive(false);

        isScanned = false;

        xSpeed = 0;
        ySpeed = 0;

        DefineMovement();
    }



    // Update is called once per frame
    void Update()
    {
        if(timeLeft < 0)
        {
            //Game Over
        }

        if(c && t && r && l)
        {
            //End room
        }

        if (Input.GetKeyDown(inputs[up]) || (upAssigned && Input.GetKeyDown(upCommand)) || Input.GetKeyDown(KeyCode.W))
        {
            movement.y = movementSpeed;
            upKey.text = inputs[up].ToString();
        }

        if (Input.GetKeyDown(inputs[down]) || (downAssigned && Input.GetKeyDown(downCommand)) || Input.GetKeyDown(KeyCode.S))
        {
            movement.y = -movementSpeed;
            downKey.text = inputs[down].ToString();
        }

        if (Input.GetKeyDown(inputs[left]) || (leftAssigned && Input.GetKeyDown(leftCommand)) || Input.GetKeyDown(KeyCode.A))
        {
            movement.x = -movementSpeed; 
            leftKey.text = inputs[left].ToString();
        }

        if (Input.GetKeyDown(inputs[right]) || (rightAssigned && Input.GetKeyDown(rightCommand)) || Input.GetKeyDown(KeyCode.D))
        {
            movement.x = movementSpeed;
            rightKey.text = inputs[right].ToString();
        }


        if (Input.GetKeyDown(inputs[attack]) || (attackAssigned && Input.GetKeyDown(attackCommand)))
        {
            hasAttacked = true;
            attackKey.text = inputs[attack].ToString();
        }

        if (!Input.anyKey)
        {
            movement = Vector2.zero;
        }

        timeLeft -= Time.deltaTime;
        uiTimeLeft.text = timeLeft.ToString();

        ChangeLight();
        playerLight.transform.position = playerRb.position;

    }

    void FixedUpdate()
    {
        xSpeed = movement.x * Time.fixedDeltaTime;
        ySpeed = movement.y * Time.fixedDeltaTime;
        playerRb.MovePosition(playerRb.position + movement * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        if (!isScanned)
        {
            AstarPath.active.Scan();
            isScanned = true;
        }
    }


    void DefineMovement()
    {

        if(!upAssigned)
        {
            up = Random.Range(0, inputs.Length);
            Debug.Log("Up: " + inputs[up]);
        }

        if(!downAssigned)
        {
            down = Random.Range(0, inputs.Length);

            while (down == up)
            {
                down = Random.Range(0, inputs.Length);
            }
            Debug.Log("Down: " + inputs[down]);
        }

        if(!leftAssigned)
        {
            left = Random.Range(0, inputs.Length);

            while (left == up || left == down)
            {
                left = Random.Range(0, inputs.Length);
            }

            Debug.Log("Left: " + inputs[left]);
        }

        if(!rightAssigned)
        {
            right = Random.Range(0, inputs.Length);

            while (right == up || right == down || right == left)
            {
                right = Random.Range(0, inputs.Length);
            }

            Debug.Log("Right: " + inputs[right]);
        }

        if (!attackAssigned)
        {
            attack = Random.Range(0, inputs.Length);

            while (attack == up || attack == down || attack == left || attack == right)
            {
                attack = Random.Range(0, inputs.Length);
            }

            Debug.Log("Attack: " + inputs[attack]);
        }


        if (inputs[up] == KeyCode.C || inputs[down] == KeyCode.C || inputs[left] == KeyCode.C || inputs[right] == KeyCode.C)
        {
            c = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
        }

        if (inputs[up] == KeyCode.T || inputs[down] == KeyCode.T || inputs[left] == KeyCode.T || inputs[right] == KeyCode.T)
        {
            t = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
        }

        if (inputs[up] == KeyCode.R || inputs[down] == KeyCode.R || inputs[left] == KeyCode.R || inputs[right] == KeyCode.R)
        {
            r = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
        }

        if (inputs[up] == KeyCode.L || inputs[down] == KeyCode.L || inputs[left] == KeyCode.L || inputs[right] == KeyCode.L)
        {
            l = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
        }
    }

    void ChangeLight()
    {
        foreach(Light2D light in lights)
        {
            light.intensity = Mathf.Abs(Mathf.Cos(Time.realtimeSinceStartup)) / 4f + 0.25f;
        }
    }

}
