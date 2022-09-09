using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CulPouleEndAnimation : MonoBehaviour
{
    [SerializeField] private Animator _culPouleAnimator;
    [SerializeField] private Transform _egg;
    private bool noLoop;

    private void Awake()
    {
        _culPouleAnimator.enabled = false;
    }

    void Update()
    {
        var playerPos = Player.Instance.transform.position;
        playerPos = new Vector3(Mathf.RoundToInt(playerPos.x), Mathf.RoundToInt(playerPos.y),
            Mathf.RoundToInt(playerPos.z));

        var selfPos = transform.position;
        selfPos = new Vector3(Mathf.RoundToInt(selfPos.x), Mathf.RoundToInt(selfPos.y), Mathf.RoundToInt(selfPos.z));

        if (playerPos == selfPos && !noLoop)
        {
            noLoop = true;
            // _egg.gameObject.SetActive(false);
            _culPouleAnimator.enabled = true;

            StartCoroutine(Delay());
            IEnumerator Delay()
            {
                yield return new WaitForSeconds(4);
                SceneManager.LoadScene("End");
            }
            
        }
    }
}
