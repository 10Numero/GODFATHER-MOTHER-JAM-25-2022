using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class LevelDesignHelper : MonoBehaviour
{
    [SerializeField] private Transform _tilesContainer;
    
    
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

    [Button]
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
            
                cube.UpdateSprite(SO_TileSpriteHolder.Instance.GetSprite(__type));
                
                if(cube)
                    DestroyImmediate(cube);

                switch (__type)
                {
                    case ACube.eCubeType.Jelly:
                        child.name = "Jelly ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        child.AddComponent<JellyCube>();
                        break;
                
                    case ACube.eCubeType.Oven:
                        child.name = "Oven ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        child.AddComponent<OvenCube>();
                        break;
                
                    case ACube.eCubeType.Sugar:
                        child.name = "Sugar ( " + child.transform.position.x + ", " + child.transform.position.y + " )";
                        child.AddComponent<SugarCube>();

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
}
