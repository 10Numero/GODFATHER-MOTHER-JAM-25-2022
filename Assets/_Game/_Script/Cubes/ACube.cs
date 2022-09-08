using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
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

    [OnValueChanged("SelfUpdateSprite")]public eCubeType cubeType;

    public float travelTime;

    [SerializeField] protected SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        _spriteRenderer ??= GetComponentInChildren<SpriteRenderer>();
        SelfUpdateSprite();
    }

    void Start()
    { 
        GridHelper.Instance.Register(this);
    }

    public abstract void Action();

    public void CancelAction()
    {
        StopAllCoroutines();
    }

    public void UpdateSprite(Sprite __value)
    {
        _spriteRenderer.sprite = __value;
    }
    
    private void SelfUpdateSprite()
    {
        _spriteRenderer.sprite ??= SO_TileSpriteHolder.Instance.GetSprite(cubeType);
    }
}
