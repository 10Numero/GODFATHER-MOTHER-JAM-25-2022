using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/TilesPrefabs")]
public class SO_TilePrefabs : ScriptableObject
{
    public List<GameObject> tiles = new();

    public static SO_TilePrefabs Instance => _instance ? _instance : GetInstance(); // comme un get
    

    private static SO_TilePrefabs _instance;

    static SO_TilePrefabs GetInstance()
    {
        var guid = AssetDatabase.FindAssets("Tiles");

        if (guid.Length <= 0)
            return null;

        var path = AssetDatabase.GUIDToAssetPath(guid[0]);

        _instance = AssetDatabase.LoadAssetAtPath<SO_TilePrefabs>(path);

        return _instance;
    }
}
