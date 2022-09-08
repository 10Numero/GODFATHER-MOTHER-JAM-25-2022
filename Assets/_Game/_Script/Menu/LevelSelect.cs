using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private List<string> sceneName;
    [SerializeField] private LevelSelectHandler levelButton;
    [SerializeField] private Sprite[] levelsSprite;

    private void Start()
    {
        sceneName = new List<string>();
        sceneName =  GetComponent<FindLevelInFolder>().FindLevels();
        LoadButtons();
    }
   

    public void LoadButtons() 
    {
        for (int i = 0; i < sceneName.Count; i++)
        {
            LevelSelectHandler level = Instantiate<LevelSelectHandler>(levelButton, transform);
            level.InitButton(i);
            Button button = level.GetComponent<Button>();
            button.image.sprite = levelsSprite[i];
            if (PlayerPrefs.GetInt(sceneName[i]) == 0)
            {
               button.interactable = false;
            }
        }
    }
}
