using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter: MonoBehaviour
{
    public GameObject Projectile;
    public GameObject BoosterPosition;
    public GameObject sfx;

    public GameObject special;
    int delay = 0;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && delay == 0)
        {
            Instantiate(Projectile, BoosterPosition.transform.position, transform.rotation);
            delay = 400;
            sfx.GetComponent<AudioManager>().PlaySFXReference(3);
        }
    }
    
    void FixedUpdate()
    {
        if (delay > 0) { delay--; }
        special.transform.localScale = new Vector3(0.66f-0.66f*(delay/400f),0.66f,0.66f);
    }
}
