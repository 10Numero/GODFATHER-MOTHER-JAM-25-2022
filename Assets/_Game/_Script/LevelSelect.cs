using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private string[] sceneName;
    [SerializeField] private LevelSelectHandler levelButton;

    private void Start()
    {
        LoadButtons();
    }

    public void FindLevels()
    {

    }

    public void LoadButtons() 
    {
        for (int i = 0; i < sceneName.Length; i++)
        {
            LevelSelectHandler level = Instantiate<LevelSelectHandler>(levelButton, transform);
            level.InitButton(sceneName[i]);
        }
    }
}
