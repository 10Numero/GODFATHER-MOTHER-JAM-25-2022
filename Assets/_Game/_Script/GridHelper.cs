using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static GridHelper Instance { get; private set; }

    // Temp -> get dynamic ref of player
    public Transform player;

    private List<ACube> _cubes = new();
    
    public enum BoxType
    {
        Sugar,
        Four,
        Jelly
    };

    
    private void Awake()
    {
        Instance = this;
    }

    public void Register(ACube __cube)
    {
        _cubes.Add(__cube);
    }

    public void GetEndPosition(BoxType __boxType, Transform __hookedBox)
    {
        switch (__boxType)
        {
            case BoxType.Four:
                
                break;
            case BoxType.Jelly:
                break;
            case BoxType.Sugar:
                break;
            default:
                break;
        }
    }

    void GetTilePosition(Transform __target)
    {
        
    }
}
