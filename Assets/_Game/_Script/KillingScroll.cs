using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class KillingScroll : MonoBehaviour
{

    [SerializeField] int tolerance;
    [SerializeField] int killingValue;

    private void Update()
    {
        testKillPlayer();
    }

    [Button]
    public void testKillPlayer()
    {
        if (Camera.main.transform.position.z > Player.Instance.transform.position.z + killingValue + tolerance)
        {
            Debug.Log("Player killed");
        }
        else
        {
            Debug.Log("Player safe");
        }
    }
}
