using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class OvenCube : ACube
{
    private void Start()
    {
        cubeType = eCubeType.Oven;
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
            Vector3 startPos = Player.Instance.transform.position;
            var endPos = GridHelper.Instance.GetEndPosition(cubeType, transform).Item1;

            var dst = Vector3.Distance(Player.Instance.transform.position, endPos);

            float t = 0;

            while (t < 1)
            {
                t += (speed / dst) * Time.deltaTime;
                Player.Instance.transform.position = Vector3.Lerp(startPos, endPos, t);
                yield return null;
            }
            Player.Instance.transform.position = endPos;
            OnReachDest?.Invoke();
        }
    }

    
}
