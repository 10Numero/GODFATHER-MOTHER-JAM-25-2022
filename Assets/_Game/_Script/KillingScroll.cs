using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

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
        if (Camera.main.transform.position.x > Player.Instance.transform.position.x + killingValue + tolerance)
        {
            SceneManager.LoadScene("Loose");
        }
    }
}
