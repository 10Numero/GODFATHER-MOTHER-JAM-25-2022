using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipManager : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private LineRenderer lineRenderer;
    private bool hasInput = false;
    [SerializeField] private float whipTime = 1f;
    private float timer = 0;

    private Vector2 targetPos;
    private RaycastHit2D _raycastHit;

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
            Debug.DrawLine(transform.position, transform.position + (Vector3)direction, Color.red, 5);
            if (_raycastHit.collider != null)
            {
                Debug.Log(_raycastHit.collider.name);
                targetPos = _raycastHit.transform.position;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, transform.position);
                lineRenderer.enabled = true;
            }
            timer = whipTime;
        }

    }

    private void WhipHit()
    {
        var cube = _raycastHit.collider.transform.gameObject.GetComponent<ACube>();

        if (cube)
        {
            cube.Action();
        }
    }

}
