using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACube : MonoBehaviour
{

    void Awake()
    { 
        GridHelper.Instance.Register(this);
    }

    public abstract void Action();
}
