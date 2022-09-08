using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private RectTransform title;
    [SerializeField] private RectTransform background;
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private RectTransform mainMenu;
    [SerializeField] private FadeToLevelSelect whipEffect;
    private bool inIntroSequence = true;

    private void Start()
    {
        IntroSequence();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (inIntroSequence)
            {
                background.DOComplete();
            }
            else
            {
                StartScreenMove();

            }
        }      
    }

    public void IntroSequence()
    {
        background.DOAnchorPosY(0, 6).onComplete += FadeInOutText;
    }

    public void StartScreenMove()
    {
        whipEffect.WhipEffectToSelect(false);
        Sequence seq = DOTween.Sequence();
        seq.Append(title.DOAnchorPosX(800, 1));
        seq.Insert(0, mainMenu.DOAnchorPosX(0, 1));
        startText.DOKill();
    }

    public void FadeInOutText()
    {
        inIntroSequence = false;
        Sequence seq = DOTween.Sequence();
        seq.Append(startText.DOColor(Color.clear, 1.5f).SetEase(Ease.InOutSine));
        seq.Append(startText.DOColor(Color.white, 1.5f).SetEase(Ease.InOutSine));
        seq.Play();
        seq.SetLoops(-1);
    }
}
