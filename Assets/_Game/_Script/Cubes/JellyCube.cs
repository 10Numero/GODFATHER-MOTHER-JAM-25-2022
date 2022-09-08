using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class JellyCube : ACube
{
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
        StartCoroutine(Animation());

        IEnumerator Animation()
        {
            Vector3 startPos = transform.position;
            Vector3 playerStartPos = Player.Instance.transform.position;
            var positions = GridHelper.Instance.GetEndPosition(cubeType, transform);

            float elapsedTime = 0;

            while (elapsedTime < travelTime)
            {
                elapsedTime += Time.deltaTime;
                Player.Instance.transform.position = Vector3.Lerp(playerStartPos, positions.Item1, elapsedTime / travelTime);
                transform.position = Vector3.Lerp(startPos, positions.Item2, elapsedTime / travelTime);
                yield return null;
            }
            transform.position = positions.Item2;
            Player.Instance.transform.position = positions.Item1;

        }
    }
}
