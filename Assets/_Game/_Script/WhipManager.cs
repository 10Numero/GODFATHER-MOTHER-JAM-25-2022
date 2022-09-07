using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipManager : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float whipTime = 1f;
    private bool hasInput = false;
    private float timer = 0;

    private Vector2 targetPos;
    private RaycastHit2D _raycastHit;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip whipLaunchOvenClip;
    [SerializeField] private AudioClip whipLaunchSugerClip;
    [SerializeField] private AudioClip whipHitOvenClip;
    [SerializeField] private AudioClip whipHitSugerClip;
    [SerializeField] private AudioClip whipHitJellyClip;

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (hasInput)
        {
            timer -= Time.deltaTime;

            lineRenderer.SetPosition(1, Vector3.Lerp(targetPos, transform.position, timer / whipTime));

            if (timer <= 0)
            {
                WhipHit();
                hasInput = false;
                lineRenderer.enabled = false;
            }
            return;
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            float x = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            direction = new Vector2(x, 0);
            hasInput = true;
        }
        else if (Input.GetAxis("Vertical") != 0) //only 1 input at a time?
        {
            float y = Input.GetAxis("Vertical") > 0 ? 1 : -1;
            direction = new Vector2(0, y);
            hasInput = true;
        }

        if (hasInput)
        {
            _raycastHit = Physics2D.Raycast(transform.position, direction);
            if (_raycastHit.collider != null)
            {
                targetPos = _raycastHit.transform.position;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position);
                lineRenderer.enabled = true;
            }
            timer = whipTime;
            var cube = _raycastHit.collider.transform.gameObject.GetComponent<ACube>();
            switch (cube.cubeType)
            {
                case ACube.eCubeType.Oven:
                    audioSource.clip = whipLaunchOvenClip;
                    break;
                case ACube.eCubeType.Sugar:
                case ACube.eCubeType.Jelly:
                    audioSource.clip = whipLaunchSugerClip;
                    break;
                case ACube.eCubeType.Caramel:
                    break;
                default:
                    break;
            }
            audioSource.Play();
            Debug.Log(cube.cubeType);

        }

    }

    private void WhipHit()
    {
       
        var cube = _raycastHit.collider.transform.gameObject.GetComponent<ACube>();

        if (cube)
        {
            cube.Action();
        }

        switch (cube.cubeType)
        {
            case ACube.eCubeType.Oven:
                audioSource.clip = whipHitOvenClip;
                break;
            case ACube.eCubeType.Sugar:
                audioSource.clip = whipHitSugerClip;
                break;
            case ACube.eCubeType.Jelly:
                audioSource.clip = whipHitJellyClip;
                break;
            case ACube.eCubeType.Caramel:
                break;
            default:
                break;
        }
        audioSource.Play();
    }

}
