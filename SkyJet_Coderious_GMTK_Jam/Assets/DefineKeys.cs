using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefineKeys : MonoBehaviour
{
    public TextMeshProUGUI buttonUp, buttonDown, buttonLeft, buttonRight, buttonBlock, buttonAttack;
    public GameObject panel;

    public void AssignKeyUp()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                buttonUp.text = vKey.ToString();
            }
        }
    }

    public void AssignKeyDown()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                buttonDown.text = vKey.ToString();
            }
        }
    }

    public void AssignKeyLeft()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                buttonLeft.text = vKey.ToString();
            }
        }
    }

    public void AssignKeyRight()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                buttonRight.text = vKey.ToString();
            }
        }
    }

    public void AssignKeyBlock()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                buttonBlock.text = vKey.ToString();
            }
        }
    }

    public void AssignKeyAttack()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                buttonAttack.text = vKey.ToString();
            }
        }
    }

    public void Validate()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        Debug.Log(Time.timeScale);
    }
}
