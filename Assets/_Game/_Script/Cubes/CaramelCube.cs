using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CaramelCube : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WhipManager whip= other.GetComponent<WhipManager>();
            whip.StopAllCoroutines();
            whip.EndAnimation();
            ACube cube = other.GetComponent<Player>().lastHittedCube;
            other.transform.position = this.transform.position;
            cube.CancelAction();
            
        }else if(other.GetComponent<SugarCube>() != null)
        {
            ACube cube = other.GetComponent<SugarCube>();
            cube.CancelAction();
            other.transform.position = this.transform.position;
            Player.Instance.GetComponent<WhipManager>().StopAllCoroutines();
            Player.Instance.GetComponent<WhipManager>().EndAnimation();
        }/*else if(other.GetComponent<JellyCube>() != null)
        {
            ACube cube = other.GetComponent<JellyCube>();
            cube.CancelAction();
            other.transform.position = this.transform.position;
            Player.Instance.GetComponent<WhipManager>().StopAllCoroutines();
            Player.Instance.GetComponent<WhipManager>().EndAnimation();
        }*/
    }
}
