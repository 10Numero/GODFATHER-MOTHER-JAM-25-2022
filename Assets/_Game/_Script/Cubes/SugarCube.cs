using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SugarCube : ACube
{
    private void Start()
    {
        cubeType = eCubeType.Sugar;
    }
    public override void Action()
    {
        MoveToPosition();
    }

    [Button]
    private void MoveToPosition()
    {
        StartCoroutine(Animation());

        IEnumerator Animation()
        {
            Vector3 startPos = transform.position;
            var endPos = GridHelper.Instance.GetEndPosition(cubeType, transform).Item2;

            var dst = Vector3.Distance(Player.Instance.transform.position, endPos);

            float t = 0;

            while (t < 1)
            {
                t += (speed / dst) * Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }
            transform.position = endPos;
            OnReachDest?.Invoke();
        }
    }
}
