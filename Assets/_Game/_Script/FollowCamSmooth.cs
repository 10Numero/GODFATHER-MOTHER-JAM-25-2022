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

    void Update()
    {
        if(followX || followY)
            SmoothCam();
    }

    private void SmoothCam()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(followX ? Player.Instance.transform.position.x : xPos, 
                followY ? Player.Instance.transform.position.y : transform.position.y, zPos),
            smoothSpeed * Time.deltaTime);
    }
}
