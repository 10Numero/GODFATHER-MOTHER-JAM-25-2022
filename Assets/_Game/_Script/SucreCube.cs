using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class SucreCube : ACube
{
    [SerializeField] GameObject player;
    [SerializeField] float travelTime;
    
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
            Vector3 currentPos = startPos;
            Vector3 endPos = player.transform.position;

            float elapsedTime = 0;

            while (elapsedTime < travelTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / travelTime);
                yield return null;
            }
            transform.position = endPos;
        }
    }

    
}
