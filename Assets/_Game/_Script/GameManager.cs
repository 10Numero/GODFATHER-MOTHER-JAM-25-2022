using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }
    private static GameManager instance;

    private int currentLevel = 0;
    public List<string> allLevels;

    [SerializeField] private Image fadeBackground;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip bossMusic;

    void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        allLevels = new List<string>();
        allLevels = GetComponent<FindLevelInFolder>().FindLevels();
        PlayerPrefs.SetInt("Level_1", 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt(allLevels[currentLevel], 1);
        PlayerPrefs.Save();
        fadeBackground.DOColor(Color.black, 1);
        StartCoroutine(WaitFade());
    }

    public void RestartLevel()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(allLevels[currentLevel]);
    }

    IEnumerator WaitFade()
    {
        yield return new WaitForSeconds(1);

        if (currentLevel >= allLevels.Count)
        {
            SceneManager.LoadScene("MainMenu");
            audioSource.clip = menuMusic;
            audioSource.Play();
        }
        else
        {
            SceneManager.LoadScene(allLevels[currentLevel]);
            if (currentLevel == 5)
            {
                audioSource.clip = bossMusic;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = gameMusic;
            }
            fadeBackground.DOColor(Color.clear, 1);
        }
    }


    public void QuitApp()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelNum)
    {
        currentLevel = levelNum;
        fadeBackground.DOColor(Color.black, 1);
        StartCoroutine(WaitFade());
    }
}
