using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<string> sceneName;
    [SerializeField] private LevelSelectHandler levelButton;
    [SerializeField] private string path;

    private void Start()
    {
        LoadButtons();
    }

    [Button("Find Levels")]
    public void FindLevels()
    {
        sceneName.Clear();
        sceneName = new List<string>();
        var fullPath = Application.dataPath  + path;
        Debug.Log("fullPath: " + fullPath);
        DirectoryInfo dirInfo = new DirectoryInfo(fullPath);
        foreach (var file in dirInfo.GetFiles())
        {
            if (file.Name.Contains("Level") && !file.Name.Contains(".meta"))
            {
                sceneName.Add(file.Name.Substring(0 , file.Name.Length -6));
            }
        }
    }

    public void LoadButtons() 
    {
        for (int i = 0; i < sceneName.Count; i++)
        {
            LevelSelectHandler level = Instantiate<LevelSelectHandler>(levelButton, transform);
            level.InitButton(sceneName[i]);
        }
    }
}
