using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BoosterPosition;


    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
            Instantiate (Projectile,BoosterPosition.transform.position, Quaternion.identity);

    }
}
