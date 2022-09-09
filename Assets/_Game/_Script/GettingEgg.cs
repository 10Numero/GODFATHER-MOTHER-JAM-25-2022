using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GettingEgg : MonoBehaviour
{
    [SerializeField] AudioClip son;
    [SerializeField] AudioSource audiosource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audiosource.PlayOneShot(son);
            Destroy(gameObject);
        }
    }
}
