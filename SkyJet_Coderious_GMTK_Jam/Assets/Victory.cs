using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
