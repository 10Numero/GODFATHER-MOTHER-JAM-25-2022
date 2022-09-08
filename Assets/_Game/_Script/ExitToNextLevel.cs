using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToNextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        GameManager.Instance.LoadNextLevel();
    }
}
