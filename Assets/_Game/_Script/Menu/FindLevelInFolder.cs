using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FindLevelInFolder : MonoBehaviour
{
    public List<string> FindLevels()
    {
        List<string> sceneName;
        sceneName = new List<string>();
        var fullPath = Application.dataPath + "/_Game/Scenes/Levels";
        Debug.Log("fullPath: " + fullPath);
        DirectoryInfo dirInfo = new DirectoryInfo(fullPath);
        foreach (var file in dirInfo.GetFiles())
        {
            if (file.Name.Contains("Level") && !file.Name.Contains(".meta"))
            {
                sceneName.Add(file.Name.Substring(0, file.Name.Length - 6));
            }
        }
        return sceneName;
    }
}
