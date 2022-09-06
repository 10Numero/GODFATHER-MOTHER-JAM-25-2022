using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Bezier : MonoBehaviour
{
    [Range(0, 1)]
    public float a;


    public Transform tA;
    public Transform tB;
    public Transform tC;
    public Transform target;

    private void Update()
    {
        var lerpA = Vector3.Lerp(tA.position, tB.position, a);
        var lerpB = Vector3.Lerp(tB.position, tC.position, a);
        var lerpc = Vector3.Lerp(lerpA, lerpB, a);

        target.position = lerpc;
    }
}
