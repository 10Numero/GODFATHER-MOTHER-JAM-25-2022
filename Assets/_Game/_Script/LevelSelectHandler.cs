using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelectHandler : MonoBehaviour
{
    private string levelName;
    [SerializeField] private TextMeshProUGUI levelText;

    public void InitButton(string sceneName)
    {
        levelName = sceneName;
        levelText.SetText(sceneName);
    }

    public void LoadCurrentLevel()
    {
        MenuManager.Instance.LoadLevel(levelName);
    }
}
