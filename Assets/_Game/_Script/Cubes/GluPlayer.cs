using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluPlayer : MonoBehaviour
{
    [SerializeField] List<GameObject> neighbourTiles;
    protected int targetedNeightbour;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //GameObject player = other.gameObject.transform.GetComponent<PlayerMovement>();
            //player.StopMove();
            //player.MovePlayer(neighbourTiles[targetedNeightbour]);
        }
    }
}
