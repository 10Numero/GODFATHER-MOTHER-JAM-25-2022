using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCube : ACube
{
    bool alrdyHit = false;

    public override void Action()
    {
        Hitted();
    }

    public void Hitted()
    {
        if (!alrdyHit)
        {
            //Changement de sprite
            alrdyHit = true;
        }
        else
        {
            //Recuperer le blanc d'oeuf
            Destroy(gameObject);
        }
    }
}
