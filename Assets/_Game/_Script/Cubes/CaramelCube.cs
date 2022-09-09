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
           
            cube.CancelAction();




            /*Debug.Log("caramel : " + transform.position);
            Debug.Log("Player : " + other.transform.position);*/


            /*if (other.transform.position.y > transform.position.y) // En haut
            {
                Debug.Log("Joueur detecter en haut");
                other.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y + 1,
                                                        other.transform.position.z);
            }
            else if (other.transform.position.x > transform.position.x) // A droite
            {
                Debug.Log("Joueur detecter à droite");

                other.transform.position = new Vector3(transform.position.x + 1,
                                                        transform.position.y,
                                                        other.transform.position.z);
            }
            else if (other.transform.position.y < transform.position.y) // En bas
            {
                Debug.Log("Joueur detecter en bas");

                other.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y - 1,
                                                        other.transform.position.z);
            }
            else if (other.transform.position.x < transform.position.x) // A gauche
            {
                Debug.Log("Joueur detecter à gauche");

                other.transform.position = new Vector3(transform.position.x - 1,
                                                        transform.position.y,
                                                        other.transform.position.z);
            }*/





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





        /*Debug.Log("caramel : " + transform.position);
        Debug.Log("Player : " + other.transform.position);*/

        Vector3 playerDirection = transform.position - Player.Instance.transform.position;

        Debug.Log("PlayerDirection: " + playerDirection);

        if (IsOnTheLeft(playerDirection))
        {
            Debug.Log("Left");

            /*other.transform.position = new Vector3(transform.position.x - 1,
                                                        transform.position.y,
                                                        other.transform.position.z);*/
        }
        else if (!IsOnTheLeft(playerDirection))
        {
            Debug.Log("Right");

            /*other.transform.position = new Vector3(transform.position.x + 1,
                                                        transform.position.y,
                                                        other.transform.position.z);*/
        }
        else if (IsOnTheTop(playerDirection))
        {
            Debug.Log("Top");

            /*other.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y + 1,
                                                        other.transform.position.z);*/
        }
        else if (!IsOnTheTop(playerDirection))
        {
            Debug.Log("Bottom");

            /*other.transform.position = new Vector3(transform.position.x,
                                                        transform.position.y - 1,
                                                        other.transform.position.z);*/
        }
        

    }

    bool IsOnTheTop(Vector3 __dir)
    {
        var dir = Vector3.Cross(Player.Instance.transform.InverseTransformDirection(Vector3.left), __dir);
        return dir.z >= 1;
    }

    bool IsOnTheLeft(Vector3 __dir)
    {
        var dir = Vector3.Cross(Player.Instance.transform.transform.up, __dir);
        Debug.Log("return : " + (!(dir.z <= 1)));
        return dir.z <= -1;
    }
}
