using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamSmooth : MonoBehaviour
{
    public bool followX;
    public bool followY;
    
    public float xPos;
    public float zPos = -10;

    public float smoothSpeed = 1;

    public Transform camCollider;

    public Vector2 xLimit;
    public Vector2 yLimit;

    private void Awake()
    {
        var pos = camCollider.transform.position;
        var scale = camCollider.transform.localScale / 2;

        xLimit = new Vector2(pos.x - scale.x, pos.x + scale.x);
        yLimit = new Vector2(pos.y - scale.y, pos.y + scale.y);
    }

    void Update()
    {
        if(followX || followY)
            SmoothCam();
    }

    private void SmoothCam()
    {
        var pos =Vector3.Lerp(
            transform.position, 
            new Vector3(followX ? Player.Instance.transform.position.x : xPos, 
                followY ? Player.Instance.transform.position.y : transform.position.y, zPos),
            smoothSpeed * Time.deltaTime);

        if (pos.x < xLimit.x)
        {
            // Debug.Log("limit xx");
            pos.x = xLimit.x;
        }
        else if (pos.x > xLimit.y)
        {
            // Debug.Log("limit xy");
            pos.x = xLimit.y;
        }

        if (pos.y < yLimit.x)
        {
            // Debug.Log("limit yx");
            pos.y = yLimit.x;
        }
        else if (pos.y > yLimit.y)
        {
            // Debug.Log("limit yy");
            pos.y = yLimit.y;
        }
        
        transform.position = pos;
    }
}
