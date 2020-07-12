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

    public float timeLeft = 60f;

    public TextMeshProUGUI uiTimeLeft;
    public TextMeshProUGUI cLetter, tLetter, rLetter, lLetter;

    Vector2 movement;

    public bool c, t, r, l;
    public bool upAssigned, downAssigned, leftAssigned, rightAssigned, attackAssigned;
    public KeyCode upCommand, downCommand, leftCommand, rightCommand, attackCommand;

    public TextMeshProUGUI upKey, downKey, leftKey, rightKey, attackKey;

    public Light2D[] lights = new Light2D[4];

    public AnimationCurve curve;

    public bool isScanned;

    public bool isUnderControl;

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

    public GameObject victoryPanel, gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;

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
        isUnderControl = true;

        xSpeed = 0;
        ySpeed = 0;

        upKey.text = "W";
        downKey.text = "S";
        leftKey.text = "A";
        rightKey.text = "D";


        DefineMovement();
    }



    // Update is called once per frame
    void Update()
    {
        if(timeLeft < 0)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

        }

        if(!isUnderControl)
        {
            if (Input.GetKeyDown(inputs[up]) || (upAssigned && Input.GetKeyDown(upCommand)))
            {
                movement.y = movementSpeed;
                if (upAssigned)
                {
                    upKey.text = upCommand.ToString();
                }
                else
                {
                    upKey.text = inputs[up].ToString();
                }

            }

            if (Input.GetKeyDown(inputs[down]) || (downAssigned && Input.GetKeyDown(downCommand)))
            {
                movement.y = -movementSpeed;
                if (downAssigned)
                {
                    downKey.text = downCommand.ToString();
                }
                else
                {
                    downKey.text = inputs[down].ToString();
                }
            }

            if (Input.GetKeyDown(inputs[left]) || (leftAssigned && Input.GetKeyDown(leftCommand)))
            {
                movement.x = -movementSpeed;
                if (leftAssigned)
                {
                    leftKey.text = leftCommand.ToString();
                }
                else
                {
                    leftKey.text = inputs[left].ToString();
                }
            }

            if (Input.GetKeyDown(inputs[right]) || (rightAssigned && Input.GetKeyDown(rightCommand)))
            {
                movement.x = movementSpeed;
                if (rightAssigned)
                {
                    rightKey.text = rightCommand.ToString();
                }
                else
                {
                    rightKey.text = inputs[right].ToString();
                }
            }


            if (Input.GetKeyDown(inputs[attack]) || (attackAssigned && Input.GetKeyDown(attackCommand)))
            {
                hasAttacked = true;
                if (attackAssigned)
                {
                    attackKey.text = attackCommand.ToString();
                }
                else
                {
                    attackKey.text = inputs[attack].ToString();
                }
            }
        }
        else
        {
            movement.x = Input.GetAxis("Horizontal") * movementSpeed;
            movement.y = Input.GetAxis("Vertical") * movementSpeed;
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


    public void DefineMovement()
    {

        if(!upAssigned)
        {
            up = Random.Range(0, inputs.Length);

            while(inputs[up] == downCommand || inputs[up] == leftCommand || inputs[up] == rightCommand || inputs[up] == attackCommand)
            {
                up = Random.Range(0, inputs.Length);
            }

            Debug.Log("Up: " + inputs[up]);
        }

        if(!downAssigned)
        {
            down = Random.Range(0, inputs.Length);

            while (down == up || inputs[down] == upCommand || inputs[down] == leftCommand || inputs[down] == rightCommand || inputs[down] == attackCommand)
            {
                down = Random.Range(0, inputs.Length);
            }
            Debug.Log("Down: " + inputs[down]);
        }

        if(!leftAssigned)
        {
            left = Random.Range(0, inputs.Length);

            while (left == up || left == down || inputs[left] == upCommand || inputs[left] == downCommand || inputs[left] == rightCommand || inputs[left] == attackCommand)
            {
                left = Random.Range(0, inputs.Length);
            }

            Debug.Log("Left: " + inputs[left]);
        }

        if(!rightAssigned)
        {
            right = Random.Range(0, inputs.Length);

            while (right == up || right == down || right == left || inputs[right] == upCommand || inputs[right] == downCommand || inputs[right] == leftCommand || inputs[right] == attackCommand)
            {
                right = Random.Range(0, inputs.Length);
            }

            Debug.Log("Right: " + inputs[right]);
        }

        if (!attackAssigned)
        {
            attack = Random.Range(0, inputs.Length);

            while (attack == up || attack == down || attack == left || attack == right || inputs[attack] == upCommand || inputs[attack] == downCommand || inputs[attack] == leftCommand || inputs[attack] == rightCommand)
            {
                attack = Random.Range(0, inputs.Length);
            }

            Debug.Log("Attack: " + inputs[attack]);
        }


        if ((inputs[up] == KeyCode.C || inputs[down] == KeyCode.C || inputs[left] == KeyCode.C || inputs[right] == KeyCode.C) && !c && !isUnderControl)
        {
            c = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
            cLetter.gameObject.SetActive(true);
        }

        if ((inputs[up] == KeyCode.T || inputs[down] == KeyCode.T || inputs[left] == KeyCode.T || inputs[right] == KeyCode.T) && !t && !isUnderControl)
        {
            t = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
            tLetter.gameObject.SetActive(true);
        }

        if ((inputs[up] == KeyCode.R || inputs[down] == KeyCode.R || inputs[left] == KeyCode.R || inputs[right] == KeyCode.R) && !r && !isUnderControl)
        {
            r = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
            rLetter.gameObject.SetActive(true);
        }

        if ((inputs[up] == KeyCode.L || inputs[down] == KeyCode.L || inputs[left] == KeyCode.L || inputs[right] == KeyCode.L) && !l && !isUnderControl)
        {
            l = true;
            Time.timeScale = 0;
            commandPanel.SetActive(true);
            lLetter.gameObject.SetActive(true);
        }
    }

    void ChangeLight()
    {
        foreach(Light2D light in lights)
        {
            light.intensity = Mathf.Abs(Mathf.Cos(Time.realtimeSinceStartup)) / 4f + 0.25f;
        }
    }

    public void ResetCommandUIText()
    {
        if(!upAssigned)
        {
            upKey.text = "";
        }

        if (!downAssigned)
        {
            downKey.text = "";
        }

        if (!leftAssigned)
        {
            leftKey.text = "";
        }

        if (!rightAssigned)
        {
            rightKey.text = "";
        }

        if (!attackAssigned)
        {
            attackKey.text = "";
        }
    }

}
