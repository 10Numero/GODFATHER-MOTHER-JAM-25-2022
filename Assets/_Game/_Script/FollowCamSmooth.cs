using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamSmooth : MonoBehaviour
{
    public float xPos;
    public float zPos;

    void Update()
    {
        transform.position = new Vector3(xPos,Player.Instance.transform.position.y, zPos);
    }
}
