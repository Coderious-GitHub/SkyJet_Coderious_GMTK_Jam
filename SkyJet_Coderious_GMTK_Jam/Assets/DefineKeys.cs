using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefineKeys : MonoBehaviour
{
    public TextMeshProUGUI buttonUp, buttonDown, buttonLeft, buttonRight, buttonBlock, buttonAttack;
    public GameObject panel;

    GameManager gameManager;

    bool choiceMade;

    private void Start()
    {
        choiceMade = false;
        gameManager = FindObjectOfType<GameManager>();
    }


    public void AssignKeyUp()
    {
        if(buttonUp.text == "" && !choiceMade)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    buttonUp.text = vKey.ToString();
                    choiceMade = true;
                    gameManager.upCommand = vKey;
                    gameManager.upAssigned = true;
                }
            }
        }
    }

    public void AssignKeyDown()
    {
        if (buttonDown.text == "" && !choiceMade)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    buttonDown.text = vKey.ToString();
                    choiceMade = true;
                    gameManager.downCommand = vKey;
                    gameManager.downAssigned = true;
                }
            }
        }
    }

    public void AssignKeyLeft()
    {
        if (buttonLeft.text == "" && !choiceMade)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    buttonLeft.text = vKey.ToString();
                    choiceMade = true;
                    gameManager.leftCommand = vKey;
                    gameManager.leftAssigned = true;
                }
            }
        }
    }

    public void AssignKeyRight()
    {
        if (buttonRight.text == "" && !choiceMade)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    buttonRight.text = vKey.ToString();
                    choiceMade = true;
                    gameManager.rightCommand = vKey;
                    gameManager.rightAssigned = true;
                }
            }
        }
    }

    public void AssignKeyBlock()
    {
        if (buttonBlock.text == "" && !choiceMade)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    buttonBlock.text = vKey.ToString();
                    choiceMade = true;
                    gameManager.blockCommand = vKey;
                    gameManager.blockAssigned = true;
                }
            }
        }
    }

    public void AssignKeyAttack()
    {
        if (buttonAttack.text == "" && !choiceMade)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    buttonAttack.text = vKey.ToString();
                    choiceMade = true;
                    gameManager.attackCommand = vKey;
                    gameManager.attackAssigned = true;
                }
            }
        }
    }

    public void Validate()
    {
        choiceMade = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
