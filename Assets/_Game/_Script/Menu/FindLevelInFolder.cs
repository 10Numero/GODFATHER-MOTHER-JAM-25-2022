using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FindLevelInFolder : MonoBehaviour
{
    public List<string> levels = new List<string>();
    
    public List<string> FindLevels()
    {
        // Ne fonctionne pas dans une build -> Le path redirige vers un projet untiy (enfin presque vu que tu fais Application.dataPath),
        // tu peux  plutôt par exemple passer par tes builds settings en itérant dedans et en récupérant seulement les lvls commancant par "Level" par ex
        // List<string> sceneName;
        // sceneName = new List<string>();
        // var fullPath = Application.dataPath + "/_Game/Scenes/Levels";
        // Debug.Log("fullPath: " + fullPath);
        // DirectoryInfo dirInfo = new DirectoryInfo(fullPath);
        // foreach (var file in dirInfo.GetFiles())
        // {
        //     if (file.Name.Contains("Level") && !file.Name.Contains(".meta"))
        //     {
        //         sceneName.Add(file.Name.Substring(0, file.Name.Length - 6));
        //     }
        // }
        // return sceneName;

        return levels;
    }
}
