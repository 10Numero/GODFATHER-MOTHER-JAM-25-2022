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
            float elapsedTime = 0;

            while (elapsedTime < travelTime)
            {
                elapsedTime += Time.deltaTime;
                Player.Instance.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / travelTime);
                yield return null;
            }
            Player.Instance.transform.position = endPos;
        }
    }

    
}
