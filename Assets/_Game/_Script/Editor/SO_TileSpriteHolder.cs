using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Tile Sprite Holder")]
public class SO_TileSpriteHolder : ScriptableObject
{
    public Sprite floorSprite;
    public Sprite wallSprite;
    public Sprite sugarSprite;
    public Sprite ovenSprite;
    public Sprite jellySprite;
    public Sprite caramelSprite;
    public Sprite enterSprite;
    public Sprite exitSprite;
    
    public static SO_TileSpriteHolder Instance => _instance ? _instance : GetInstance();
    

    private static SO_TileSpriteHolder _instance;

    static SO_TileSpriteHolder GetInstance()
    {
        var guid = AssetDatabase.FindAssets("Tile Sprite Holder");

        if (guid.Length <= 0)
            return null;

        var path = AssetDatabase.GUIDToAssetPath(guid[0]);

        _instance = AssetDatabase.LoadAssetAtPath<SO_TileSpriteHolder>(path);

        return _instance;
    }

    public Sprite GetSprite(ACube.eCubeType __type)
    {
        return __type switch
        {
            ACube.eCubeType.Jelly => jellySprite,
            ACube.eCubeType.Oven => ovenSprite,
            ACube.eCubeType.Sugar => sugarSprite,
            ACube.eCubeType.Caramel => caramelSprite,
            _ => throw new ArgumentOutOfRangeException(nameof(__type), __type, null)
        };
    }
}
