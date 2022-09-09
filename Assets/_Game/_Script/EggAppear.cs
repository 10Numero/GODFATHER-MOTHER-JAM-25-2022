using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggAppear : MonoBehaviour
{
    public void EggSpawn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
}
