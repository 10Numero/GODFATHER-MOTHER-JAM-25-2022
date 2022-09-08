using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACube : MonoBehaviour
{
    public enum eCubeType
    {
        Oven,
        Sugar,
        Jelly,
        Caramel
    }

    protected Coroutine _coroutine;

    public eCubeType cubeType;

    public float travelTime;

    void Start()
    { 
        GridHelper.Instance.Register(this);
    }

    public abstract void Action();

    public void CancelAction()
    {
        StopCoroutine(_coroutine);
    }

}
