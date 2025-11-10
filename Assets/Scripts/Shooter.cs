using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BoosterPosition;
    int delay = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && delay == 0)
        {
            Instantiate(Projectile, BoosterPosition.transform.position, transform.rotation);
            delay = 400;
        }
    }
    
    void FixedUpdate()
    {
        if (delay > 0) { delay--; }
    }
}
