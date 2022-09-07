using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Sirenix.OdinInspector;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static GridHelper Instance { get; private set; }

    // Temp -> get dynamic ref of player
    public Transform player;

    private List<ACube> _cubes = new();
    

    
    private void Awake()
    {
        Instance = this;
    }

    public void Register(ACube __cube)
    {
        _cubes.Add(__cube);
    }

    [Button]
    public void TestPosition(ACube.eCubeType __boxType, Transform __hookedBox)
    {
        var positions = GetEndPosition(__boxType, __hookedBox);
        player.position = positions.Item1;
        __hookedBox.position = positions.Item2;
    }

    // Player pos, Cube pos
    public (Vector3, Vector3) GetEndPosition(ACube.eCubeType __boxType, Transform __hookedBox)
    {
        var pos = Vector3.zero;
        
        switch (__boxType)
        {
            case ACube.eCubeType.Oven:
                
                pos = new Vector3(
                    IsEqualY(__hookedBox.position.y) ? (!IsOnTheLeft(player.position - __hookedBox.position) ? __hookedBox.transform.position.x - 1 : __hookedBox.transform.position.x + 1)  
                        : __hookedBox.transform.position.x,
                    IsEqualX(__hookedBox.position.x) ? (IsOnTheTop(player.position - __hookedBox.position) ? __hookedBox.transform.position.y - 1 : __hookedBox.transform.position.y + 1)
                        : __hookedBox.transform.position.y,
                    __hookedBox.transform.position.z);
                
                return (pos, __hookedBox.position);
                
            case ACube.eCubeType.Jelly:
                
                // Get mid positions for each targets
                pos = new Vector3(
                    IsEqualY(__hookedBox.position.x) ? __hookedBox.position.x : (__hookedBox.transform.position.x + player.transform.position.x) / 2,
                    IsEqualX(__hookedBox.position.y) ? __hookedBox.position.y : (__hookedBox.transform.position.y + player.transform.position.y) / 2,
                    player.position.z);

                // Got decimal, floor & ceil are enough to get 2 dif pos next to each other
                if (!int.TryParse(pos.x.ToString(CultureInfo.InvariantCulture), out var value))
                    return (new Vector3(Mathf.Floor(pos.x), Mathf.Floor(pos.y), pos.z), new Vector3(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y), pos.z));
                
                
                if (!int.TryParse(pos.y.ToString(CultureInfo.InvariantCulture), out var valueZ))
                    return (new Vector3(Mathf.Floor(pos.x), Mathf.Floor(pos.y), pos.z), new Vector3(Mathf.CeilToInt(pos.x), Mathf.CeilToInt(pos.y), pos.z));

 
                // Got int, have to split the pos myself
                return (pos, new Vector3(!IsEqualX(pos.x) ? pos.x + 1 : pos.x, !IsEqualY(pos.y) ? pos.y + 1 : pos.y, pos.y));
                
            case ACube.eCubeType.Sugar:

                pos = new Vector3(
                    IsEqualY(__hookedBox.position.y) ? (!IsOnTheLeft(__hookedBox.position - player.position) ? player.transform.position.x - 1 : player.transform.position.x + 1)  
                        : player.transform.position.x,
                    IsEqualX(__hookedBox.position.x) ? (IsOnTheTop(__hookedBox.position - player.position) ? player.transform.position.y - 1 : player.transform.position.y + 1)
                        : player.transform.position.y,
                    player.transform.position.z);

                return (player.position, pos);
            
            default:
                throw new ArgumentOutOfRangeException(nameof(__boxType), __boxType, null);
        }
    }


    [Button]
    void TestCrossProduct(Transform __trA, Transform __trB)
    {
        var dirA = __trB.position - __trA.position;

        IsOnTheLeft(dirA);
    }
    
    bool IsOnTheLeft(Vector3 __dir)
    {
        var dir = Vector3.Cross(player.transform.up, __dir);
        return dir.z <= -1;

    }

    bool IsOnTheTop(Vector3 __dir)
    {
        var dir = Vector3.Cross(player.InverseTransformDirection(Vector3.left), __dir);
        return dir.z >= 1;
    }
    
    bool IsEqualX(float __value)
    {
        return Math.Abs(__value - player.transform.position.x) < 0.1f;
    }

    bool IsEqualY(float __value)
    {
        return Math.Abs(__value - player.transform.position.y) < 0.1f;
    }

    void GetTilePosition(Transform __target)
    {
        
    }
}
