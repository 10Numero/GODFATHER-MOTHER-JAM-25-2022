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

    [Button]
    public void TestPosition(BoxType __boxType, Transform __hookedBox)
    {
        var positions = GetEndPosition(__boxType, __hookedBox);
        player.position = positions.Item1;
        __hookedBox.position = positions.Item2;
    }

    // Player pos, Cube pos
    public (Vector3, Vector3) GetEndPosition(BoxType __boxType, Transform __hookedBox)
    {
        var pos = Vector3.zero;
        
        switch (__boxType)
        {
            case BoxType.Four:
                
                pos = new Vector3(
                    IsEqualZ(__hookedBox.position.z) ? (!IsOnTheLeft(player.position - __hookedBox.position) ? __hookedBox.transform.position.x - 1 : __hookedBox.transform.position.x + 1)  
                        : __hookedBox.transform.position.x,
                    __hookedBox.transform.position.y,
                    IsEqualX(__hookedBox.position.x) ? (!IsOnTheTop(player.position - __hookedBox.position) ? __hookedBox.transform.position.z - 1 : __hookedBox.transform.position.z + 1)
                        : __hookedBox.transform.position.z);
                
                return (pos, __hookedBox.position);
                
            case BoxType.Jelly:
                
                // Get mid positions for each targets
                pos = new Vector3(
                    IsEqualZ(__hookedBox.position.x) ? __hookedBox.position.x : (__hookedBox.transform.position.x + player.transform.position.x) / 2, 
                    player.position.y, 
                    IsEqualX(__hookedBox.position.z) ? __hookedBox.position.z : (__hookedBox.transform.position.z + player.transform.position.z) / 2);

                // Got decimal, floor & ceil are enough to get 2 dif pos next to each other
                if (!int.TryParse(pos.x.ToString(CultureInfo.InvariantCulture), out var value))
                    return (new Vector3(Mathf.Floor(pos.x), pos.y, Mathf.Floor(pos.z)), new Vector3(Mathf.CeilToInt(pos.x), pos.y, Mathf.CeilToInt(pos.z)));

                if (!int.TryParse(pos.z.ToString(CultureInfo.InvariantCulture), out var valueZ))
                    return (new Vector3(Mathf.Floor(pos.x), pos.y, Mathf.Floor(pos.z)), new Vector3(Mathf.CeilToInt(pos.x), pos.y, Mathf.CeilToInt(pos.z)));

                // Got int, have to split the pos myself
                return (pos, new Vector3(!IsEqualX(pos.x) ? pos.x + 1 : pos.x, pos.y, !IsEqualZ(pos.z) ? pos.z + 1 : pos.z));
                
            case BoxType.Sugar:

                pos = new Vector3(
                    IsEqualZ(__hookedBox.position.z) ? (!IsOnTheLeft(__hookedBox.position - player.position) ? player.transform.position.x - 1 : player.transform.position.x + 1)  
                        : player.transform.position.x,
                    player.transform.position.y,
                    IsEqualX(__hookedBox.position.x) ? (!IsOnTheTop(__hookedBox.position - player.position) ? player.transform.position.z - 1 : player.transform.position.z + 1)
                        : player.transform.position.z);
                
                return (pos, player.position);
            
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
        var dir = Vector3.Cross(player.transform.forward, __dir);
        return dir.y >= -1;

    }

    bool IsOnTheTop(Vector3 __dir)
    {
        var dir = Vector3.Cross(player.InverseTransformDirection(Vector3.left), __dir);
        return dir.y >= 1;
    }
    
    bool IsEqualX(float __value)
    {
        return Math.Abs(__value - player.transform.position.x) < 0.1f;
    }

    bool IsEqualZ(float __value)
    {
        return Math.Abs(__value - player.transform.position.z) < 0.1f;
    }

    void GetTilePosition(Transform __target)
    {
        
    }
}
