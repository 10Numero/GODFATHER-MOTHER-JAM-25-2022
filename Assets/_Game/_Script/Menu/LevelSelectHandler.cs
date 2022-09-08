using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSelectHandler : MonoBehaviour
{
    private int levelNum;

    public void InitButton(int sceneNum)
    {
        levelNum = sceneNum;
    }

    public void LoadCurrentLevel()
    {
        GameManager.Instance.LoadLevel(levelNum);
    }
}
