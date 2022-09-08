using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamSmooth : MonoBehaviour
{
    public float xPos;
    public float zPos;

    public float smoothSpeed = 10f;

    void Update()
    {
        SmoothCam();
    }

    public void SmoothCam()
    {
        transform.position = Vector3.Lerp(transform.position, Player.Instance.transform.position, smoothSpeed * Time.deltaTime);
    }
}
