using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CaramelCube : MonoBehaviour
{
    [SerializeField] BoxCollider2D[] childTriggers;

    private enum PlayerPosition { Top, right, Left, Down };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WhipManager whip= other.GetComponent<WhipManager>();
            whip.StopAllCoroutines();
            whip.EndAnimation();
            ACube cube = other.GetComponent<Player>().lastHittedCube;

            /*switch (PlayerPosition)
            {
                case PlayerPosition.Top:

                default:
            }*/

            

            //other.transform.position = this.transform.position;
            cube.CancelAction();

            Debug.Log(transform.position);

            if (other.transform.position.y > transform.position.y) // En haut
            {
                Debug.Log("a");
                other.transform.position = new Vector3(transform.position.x,
                                                        other.transform.position.y,
                                                        other.transform.position.z);
            }
            else if (other.transform.position.x > transform.position.x) // A droite
            {
                Debug.Log("b");

                other.transform.position = new Vector3(transform.position.x + 1,
                                                        transform.position.y,
                                                        other.transform.position.z);
            }
            else if (other.transform.position.y < transform.position.y) // A gauche
            {
                Debug.Log("c");

                other.transform.position = new Vector3(transform.position.x - 1,
                                                        other.transform.position.y,
                                                        other.transform.position.z);
            }
            else if (other.transform.position.x < transform.position.x) // En bas
            {
                Debug.Log("d");

                other.transform.position = new Vector3(transform.position.x,
                                                        other.transform.position.y - 1,
                                                        other.transform.position.z);
            }

        }
        else if(other.GetComponent<SugarCube>() != null)
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
