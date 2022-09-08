using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public ACube lastHittedCube;

    void Awake()
    {
        Instance = this;
    }
}
