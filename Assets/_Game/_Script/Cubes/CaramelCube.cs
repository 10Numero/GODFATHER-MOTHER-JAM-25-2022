using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class CaramelCube : MonoBehaviour
{
    [SerializeField] BoxCollider2D[] childTriggers;

    [SerializeField] GameObject[] childPos;

    //[SerializeField] GameObject playerRef;

    private enum PlayerPosition { Top, right, Left, Down };


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            /*WhipManager whip= other.GetComponent<WhipManager>();
            whip.StopAllCoroutines();
            whip.EndAnimation();
            ACube cube = other.GetComponent<Player>().lastHittedCube;
           
            cube.CancelAction();*/




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


            /*Vector3 playerDirection = Player.Instance.transform.position - transform.position;

            Debug.Log("PlayerDirection: " + playerDirection);

            if (!IsOnTheLeft(playerDirection))
            {
                Debug.Log("Left");

                other.transform.position = new Vector3(childPos[3].transform.position.x,
                                                            transform.position.y,
                                                            other.transform.position.z);
            }
            else if (IsOnTheLeft(playerDirection))
            {
                Debug.Log("Right");

                other.transform.position = new Vector3(childPos[1].transform.position.x,
                                                            transform.position.y,
                                                            other.transform.position.z);
            }


            if (!IsOnTheTop(playerDirection))
            {
                Debug.Log("Top");

                other.transform.position = new Vector3(transform.position.x,
                                                            childPos[0].transform.position.y,
                                                            other.transform.position.z);
            }
            else if (IsOnTheTop(playerDirection))
            {
                Debug.Log("Bottom");

                other.transform.position = new Vector3(transform.position.x,
                                                            childPos[2].transform.position.y,
                                                            other.transform.position.z);
            }*/




        }
        /*else if(other.GetComponent<SugarCube>() != null)
        {
            ACube cube = other.GetComponent<SugarCube>();
            cube.CancelAction();
            other.transform.position = this.transform.position;
            Player.Instance.GetComponent<WhipManager>().StopAllCoroutines();
            Player.Instance.GetComponent<WhipManager>().EndAnimation();
        }*/
        /*else if(other.GetComponent<JellyCube>() != null)
        {
            ACube cube = other.GetComponent<JellyCube>();
            cube.CancelAction();
            other.transform.position = this.transform.position;
            Player.Instance.GetComponent<WhipManager>().StopAllCoroutines();
            Player.Instance.GetComponent<WhipManager>().EndAnimation();
        }*/





        /*Debug.Log("caramel : " + transform.position);
        Debug.Log("Player : " + other.transform.position);*/

        

        


    }

    /*[Button]
    public void TestingDirection()
    {
        //Vector3 playerDirection = playerRef.transform.position - transform.position;

        Debug.Log("PlayerDirection: " + playerDirection);

        if (!IsOnTheLeft(playerDirection))
        {
            Debug.Log("Left");
        }
        else if (IsOnTheLeft(playerDirection))
        {
            Debug.Log("Right");
        }


        if (!IsOnTheTop(playerDirection))
        {
            Debug.Log("Top");
        }
        else if (IsOnTheTop(playerDirection))
        {
            Debug.Log("Bottom");
        }
    }*/

    public void RepositioningPlayer(GameObject whatChild, GameObject target)
    {
        if (target.tag == "Player")
        {
            WhipManager whip = target.GetComponent<WhipManager>();
            ACube cube = target.GetComponent<Player>().lastHittedCube;
            whip.StopAllCoroutines();
            whip.EndAnimation();
            cube.CancelAction();
            Player.Instance.transform.position = whatChild.transform.position;
        }
        else if (target.GetComponent<SugarCube>() != null)
        {
            ACube cube = target.GetComponent<SugarCube>();
            cube.CancelAction();
            target.transform.position = this.transform.position;
            Player.Instance.GetComponent<WhipManager>().StopAllCoroutines();
            Player.Instance.GetComponent<WhipManager>().EndAnimation();
            cube.CancelAction();
        }

        
    }
    bool IsOnTheTop(Vector3 __dir)
    {
        //var dir = Vector3.Cross(Player.Instance.transform.InverseTransformDirection(Vector3.left), __dir);
        var dir = Vector3.Cross(Player.Instance.transform.InverseTransformDirection(Vector3.left), __dir);
        return dir.z >= 1;
    }

    bool IsOnTheLeft(Vector3 __dir)
    {
        //var dir = Vector3.Cross(Player.Instance.transform.transform.up, __dir);
        var dir = Vector3.Cross(Player.Instance.transform.transform.up, __dir);
        Debug.Log("return : " + (!(dir.z <= 1)));
        return dir.z <= -1;
    }
}
