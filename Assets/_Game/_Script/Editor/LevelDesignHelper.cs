using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class LevelDesignHelper : MonoBehaviour
{
    [SerializeField] private Transform _tilesContainer;
    [SerializeField] private SO_TileSpriteHolder _tileSpriteHolder;

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

    [Button]
    void RecursiveCubeSpritePlacement(Transform __tr, string __name = "jelly", ACube.eCubeType __type = ACube.eCubeType.Jelly)
    {
        if (__tr == null)
        {
            if(_tilesContainer == null)
                return;

            __tr = _tilesContainer;
        }

        foreach (Transform child in __tr)
        {
            if (child.name.ToLower().Contains(__name))
            {
                var cube = child.GetComponent<ACube>();

                cube.UpdateSprite(SO_TileSpriteHolder.Instance.GetSprite(__type));

                if(child.childCount > 0)
                    RecursiveCubeSetup(child, __name, __type);
            }
        }
    }

    /// <summary>
    /// Only to clean some level badly setup 
    /// </summary>
    /// <param name="__tr"></param>
    /// <param name="__type"></param>
    [Button("Clean Cube Setup")]
    void CleanCubeSetup(Transform __tr, ACube.eCubeType __type = ACube.eCubeType.Jelly)
    {
        if (__tr == null)
        {
            if(_tilesContainer == null)
                return;

            __tr = _tilesContainer;
        }

        foreach (Transform child in __tr)
        {
            if (child.childCount > 0)
            {
                var childPos = child.GetChild(0).transform.position;
                
                DestroyImmediate(child.GetChild(0).gameObject);
                
                child.transform.position = childPos;
            }
            
        }
    }
    
    [Button("Recursive Cube Setup")]
    void RecursiveCubeSetup(Transform __tr, string __name = "jelly", ACube.eCubeType __type = ACube.eCubeType.Jelly)
    {
        if (__tr == null)
        {
            if(_tilesContainer == null)
                return;

            __tr = _tilesContainer;
        }

        foreach (Transform child in __tr)
        {
            if (child.name.ToLower().Contains(__name))
            {
                var cube = child.GetComponent<ACube>();
                
                if(cube)
                    DestroyImmediate(cube);
                
                child.transform.localScale = Vector3.one * 3;
                
                switch (__type)
                {
                    case ACube.eCubeType.Jelly:
                        child.name = "Jelly ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        cube = child.AddComponent<JellyCube>();
                        cube.UpdateSprite(_tileSpriteHolder.GetSprite(__type));
                        break;
                
                    case ACube.eCubeType.Oven:
                        child.name = "Oven ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        cube = child.AddComponent<OvenCube>();
                        cube.UpdateSprite(_tileSpriteHolder.GetSprite(__type));
                        break;
                
                    case ACube.eCubeType.Sugar:
                        child.name = "Sugar ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        cube = child.AddComponent<SugarCube>();
                        cube.UpdateSprite(_tileSpriteHolder.GetSprite(__type));

                        break;
                }
                
                if(child.childCount > 0)
                    RecursiveCubeSetup(child, __name, __type);
            }
        }
    }
    
    private enum SimpleTilesType { Floor, Wall, Enter, Exit};
    
    
    [Button("Recursive Renamer")]
    void RecursiveRenamer(Transform __tr, string __name = "floor", SimpleTilesType __type = SimpleTilesType.Floor)
    {
        if (__tr == null)
        {
            if(_tilesContainer == null)
                return;

            __tr = _tilesContainer;
        }

        foreach (Transform child in __tr)
        {
            if (child.name.ToLower().Contains(__name))
            {
                switch (__type)
                {
                    case SimpleTilesType.Floor:
                        child.name = "Floor ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        break;
                    case SimpleTilesType.Wall:
                        child.name = "Wall ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        break;
                    case SimpleTilesType.Enter:
                        child.name = "Enter ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        break;
                    case SimpleTilesType.Exit:
                        child.name = "Exit ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        break;
                }
                
                if(child.childCount > 0)
                    RecursiveRenamer(child, __name, __type);
            }
        }
    }
    
    [Button("Tiles Setup")]
    void TilesSetup(string __name = "floor", SimpleTilesType __type = SimpleTilesType.Floor)
    {
        foreach (Transform child in _tilesContainer)
        {
            if (child.name.ToLower().Contains(__name))
            {

                var sr = child.GetComponent<SpriteRenderer>();
                var col = child.GetComponent<BoxCollider2D>();
                
                switch (__type)
                {
                    case SimpleTilesType.Floor:

                        if (col)
                        {
                            DestroyImmediate(col);
                        }

                        child.transform.localScale = Vector3.one * 3.2f;

                        if (!sr)
                            child.AddComponent<SpriteRenderer>().sprite = _tileSpriteHolder.floorSprite;
                        else
                            sr.sprite = _tileSpriteHolder.floorSprite;
                        
                        break;
                
                    case SimpleTilesType.Wall:
                        
                        if (!col)
                            child.AddComponent<BoxCollider2D>();
                        
                        child.transform.localScale = Vector3.one * 1.6f;
                        
                        Debug.Log("wall");
                        
                        if (!sr)
                            child.AddComponent<SpriteRenderer>().sprite = _tileSpriteHolder.wallSprite;
                        else
                            sr.sprite = _tileSpriteHolder.wallSprite;
                        
                        break;
                
                    case SimpleTilesType.Enter:
                        
                        if (!col)
                            child.AddComponent<BoxCollider2D>();
                        
                        if (!sr)
                            child.AddComponent<SpriteRenderer>().sprite = _tileSpriteHolder.enterSprite;
                        else
                            sr.sprite = _tileSpriteHolder.enterSprite;
                        
                        break;
                    
                    case SimpleTilesType.Exit:
                        
                        if (!col)
                            child.AddComponent<BoxCollider2D>();
                        
                        if (!sr)
                            child.AddComponent<SpriteRenderer>().sprite = _tileSpriteHolder.exitSprite;
                        else
                            sr.sprite = _tileSpriteHolder.exitSprite;
                        
                        break;
                }
                
            }
        }
    }

}
