using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelDesignHelper : MonoBehaviour
{
    [SerializeField] private Transform _tilesContainer;

    [SerializeField] private Vector2 _gridSize = new(10, 10);

    [SerializeField] private GameObject _floorTile;
    [SerializeField] private GameObject _wallTile;

    public Dictionary<Vector2, Transform> tiles = new();
    
   [Button]
    void CreateGrid()
    {
        for (var i = 0; i < _gridSize.x; i++)
        {
            for (var y = 0; i < _gridSize.y; i ++)
            {
                var tile = Instantiate(_floorTile, new Vector3(i, 0, y), Quaternion.Euler(new Vector3(90, 0, 0)));
                tile.transform.SetParent(_tilesContainer.GetChild(0));

                tiles[new Vector2(i, y)] = tile.transform;
            }
        }
    }
    
    [Button]
    void RandomizeTile(Sprite[] __sprites, string __tag = "Floor")
    {
        RecursiveSpriteReplacement(_tilesContainer, __sprites, __tag);   
    }

    void RecursiveSpriteReplacement(Transform __tr, Sprite[] __sprites, string __tag = "Floor")
    {
        if (__tr == null)
            return;

        foreach (Transform child in __tr)
        {
            if (child.gameObject.CompareTag(__tag))
            {
                var image = child.gameObject.GetComponent<UnityEngine.UI.Image>();
                
                if (image)
                    image.sprite = __sprites[Random.Range(0, __sprites.Length - 1)];
            }
            
            if(child.childCount > 0)
                RecursiveSpriteReplacement(child, __sprites, __tag);
        }
    }
}
