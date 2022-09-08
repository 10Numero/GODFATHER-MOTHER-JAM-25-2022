using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
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
        if(_spriteRenderer)
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
        
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
        if (!_spriteRenderer)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        
        if(_spriteRenderer)
            _spriteRenderer.sprite = __value;
    }
    
    private void SelfUpdateSprite()
    {
        if(_spriteRenderer)
            _spriteRenderer.sprite ??= SO_TileSpriteHolder.Instance.GetSprite(cubeType);
    }
}
