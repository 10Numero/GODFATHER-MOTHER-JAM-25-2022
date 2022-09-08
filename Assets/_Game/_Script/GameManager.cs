using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;

    private int currentLevel = 0;
    public List<string> allLevels;

    void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        allLevels = new List<string>();
        allLevels = GetComponent<FindLevelInFolder>().FindLevels();
    }


    public void LoadNextLevel()
    {
        currentLevel++;
        if (currentLevel >= allLevels.Count)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(allLevels[currentLevel]);
        }
    }
}
