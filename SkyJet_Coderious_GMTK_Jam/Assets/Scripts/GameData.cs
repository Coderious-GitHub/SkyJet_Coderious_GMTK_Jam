using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    public int difficulty;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

}
