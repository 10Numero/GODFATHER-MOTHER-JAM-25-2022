using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] private Transform startPos;
    [SerializeField] private Transform endPos;
    [SerializeField] private AnimationCurve posOverTime;
    [SerializeField] private float animTime;
    private float timer = 0;
    Transform cameraPos;

    void Start()
    {
        cameraPos = Camera.main.transform; 
    }

    void Update()
    {
        timer += Time.deltaTime;
        cameraPos.position = Vector3.Lerp(startPos.position, endPos.position, posOverTime.Evaluate(timer /animTime));
    }
}
