using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    public float interval = 0.05f;
    public float offset = 0.05f;
    public float duration = 0.1f;

    private Vector3 _originalPos;
    private Vector3 _shakePos;
    private float _elapsed;
    private bool _shaking;
    

    public static CameraShake Instance { get; private set; }
    
    
    private void Awake()
    {
        Instance = this;
    }

    public void Shake()
    {
        _shaking = true;
        _elapsed = 0f;
    
        StartCoroutine(ShakeAnimation());
    
        if (interval < Time.fixedDeltaTime)
            interval = Time.fixedDeltaTime;
    }
    
    void Update()
    {
        if (!_shaking)
            _originalPos = transform.position;
        else
        {
            _elapsed += Time.deltaTime;
            if (_elapsed >= duration)
                StopShake();
        }
    }

    IEnumerator ShakeAnimation()
    {
        while (_shaking)
        {
            _shakePos = _originalPos + new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), 0f);

            transform.SetPositionAndRotation(_shakePos, Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    void StopShake()
    {
        StopCoroutine(ShakeAnimation());
        _shaking = false;
        transform.SetPositionAndRotation(_originalPos, Quaternion.identity);
    }
}