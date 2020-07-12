using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu, instructions;

    private void Start()
    {
        AudioManager.instance.Stop("Battle");
        AudioManager.instance.Stop("Dungeon");
        AudioManager.instance.Play("Dungeon");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Instructions()
    {
        mainMenu.SetActive(false);
        instructions.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        instructions.SetActive(false);
        mainMenu.SetActive(true);
    }

}
