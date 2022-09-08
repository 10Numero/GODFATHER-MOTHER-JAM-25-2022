using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipManager : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform whipstartPoint;
    private float offsetX;
    [SerializeField] private float whipTime = 1f;
    private bool hasInput = false;
    private float timer = 0;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private bool whipIsMoving;

    private Vector3 targetPos;
    private RaycastHit2D _raycastHit;

    [Header("Sound")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip whipLaunchOvenClip;
    [SerializeField] private AudioClip whipLaunchSugerClip;
    [SerializeField] private AudioClip whipHitOvenClip;
    [SerializeField] private AudioClip whipHitSugerClip;
    [SerializeField] private AudioClip whipHitJellyClip;

    private void Start()
    {
        offsetX = whipstartPoint.localPosition.x;
    }

    private void Update()
    {
        GetInput();
        if (whipIsMoving)
        {
            UpdateWhipPositions();
        }
    }

    private void GetInput()
    {
        if (whipIsMoving)
        {
            return;
        }

        if (hasInput)
        {
            timer -= Time.deltaTime;

            lineRenderer.SetPosition(1, Vector3.Lerp(targetPos, whipstartPoint.position, timer / whipTime));

            if (timer <= 0)
            {
                whipIsMoving = true;
                hasInput = false;
                WhipHit();
            }
            return;
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            if(Input.GetAxis("Horizontal") > 0)
            {
                direction = new Vector2(1, 0);
                spriteRenderer.flipX = true;
                whipstartPoint.localPosition = new Vector3(- offsetX, whipstartPoint.localPosition.y, 0);
            }
            else
            {
                direction = new Vector2(-1, 0);
                spriteRenderer.flipX = false;
                whipstartPoint.localPosition =  new Vector3(+ offsetX, whipstartPoint.localPosition.y, 0);

            }
            hasInput = true;
            animator.SetFloat("Direction", direction.x);
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
                lineRenderer.SetPosition(0, whipstartPoint.position);
                lineRenderer.SetPosition(1, whipstartPoint.position);
                lineRenderer.enabled = true;
            }
            timer = whipTime;
            var cube = _raycastHit.collider.transform.gameObject.GetComponent<ACube>();
            if (!cube)
            {
                Debug.Log("Not a cube : " + _raycastHit.collider.name);
                return;
            }
            animator.SetTrigger("Whip");

            
            switch (cube.cubeType)
            {
                case ACube.eCubeType.Oven:
                    audioSource.clip = whipLaunchOvenClip;
                    animator.SetTrigger("Forward");
                    break;
                case ACube.eCubeType.Sugar:
                case ACube.eCubeType.Jelly:
                    audioSource.clip = whipLaunchSugerClip;
                    animator.SetTrigger("Backward");

                    break;
                case ACube.eCubeType.Caramel:
                    break;
                default:
                    break;
            }
            audioSource.Play();

        }

    }
    
    private void UpdateWhipPositions()
    {
        lineRenderer.SetPosition(0, whipstartPoint.position);
        lineRenderer.SetPosition(1, _raycastHit.transform.position);
    }

    private void WhipHit()
    {
        var cube = _raycastHit.collider.transform.gameObject.GetComponent<ACube>();

        if (cube)
        {
            cube.Action();
            Player.Instance.lastHittedCube = cube;
        }
        else
        {
            whipIsMoving = false;
            lineRenderer.enabled = false;
            return;
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

        Debug.Log("sub");
        cube.OnReachDest += EndAnimation;

        audioSource.Play();
    }


    public void EndAnimation()
    {

        animator.SetTrigger("Idle");

        whipIsMoving = false;
        lineRenderer.enabled = false;
    }
}
