using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu, instructions;
    public TextMeshProUGUI difficulty;
    //public Drop dropDown;

    private void Start()
    {
        AudioManager.instance.Stop("Battle");
        AudioManager.instance.Stop("Dungeon");
        AudioManager.instance.Play("Dungeon");
    }

    public void StartGame()
    {

        if (difficulty.text == "Easy")
        {
            GameData.instance.difficulty = 1;
        }

        if (difficulty.text == "Medium")
        {
            GameData.instance.difficulty = 2;
        }

        if (difficulty.text == "Difficult")
        {
            GameData.instance.difficulty = 3;
        }

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
