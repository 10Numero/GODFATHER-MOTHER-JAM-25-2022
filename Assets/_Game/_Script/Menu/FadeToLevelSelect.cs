using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeToLevelSelect : MonoBehaviour
{
    [SerializeField] private Image backScreen;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private GameObject selectScreen;
    [SerializeField] private AudioSource audioSource;
    private bool toMenu = false;

    public void StartFadeSelect()
    {
        if (toMenu)
        {
            menuScreen.SetActive(false);
            selectScreen.SetActive(true);
        }
        else
        {
            menuScreen.SetActive(true);
            startScreen.SetActive(false);
        }
    }

    public void WhipEffectToSelect(bool _toMenu = true)
    {
        toMenu = _toMenu;
        Sequence seq = DOTween.Sequence();
        seq.Append(backScreen.DOFade(1, .5f).SetEase(Ease.OutBounce));
        seq.Append(backScreen.DOFade(0, .1f)).onComplete += StartFadeSelect;
        audioSource.Play();
    }
}
