using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteInEditMode]
public class JellyCube : ACube
{
    [SerializeField] private GameObject jellyTrail;

    private void Start()
    {
        cubeType = eCubeType.Jelly;
    }
    public override void Action()
    {
        MoveToPosition();
    }

    [Button]
    private void MoveToPosition()
    {
        _coroutine = StartCoroutine(Animation());

        IEnumerator Animation()
        {
            Vector3 startPos = transform.position;
            Vector3 playerStartPos = Player.Instance.transform.position;
            var positions = GridHelper.Instance.GetEndPosition(cubeType, transform);
            Vector2 currentTrailPos = startPos;
            float t = 0;

            while (t < 1)
            {
                t += speed * Time.deltaTime;
                Player.Instance.transform.position = Vector3.Lerp(playerStartPos, positions.Item1, t);
                transform.position = Vector3.Lerp(startPos, positions.Item2, t);

                if ((currentTrailPos.x >= transform.position.x + 1 || currentTrailPos.x <= transform.position.x - 1) || (currentTrailPos.y >= transform.position.y + 1 || currentTrailPos.y <= transform.position.y - 1))
                {
                    Instantiate(jellyTrail, currentTrailPos, Quaternion.identity);
                    currentTrailPos = transform.position;
                }
                
                yield return null;
            }
            transform.position = positions.Item2;
            Player.Instance.transform.position = positions.Item1;
            OnReachDest?.Invoke();

        }
    }


}
