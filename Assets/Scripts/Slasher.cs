using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    public GameObject slash;
    public GameObject BoosterPosition;
    public GameObject special;
    public GameObject sfx;

    float delay = 0;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && delay <= 0)
        {
            Instantiate(slash, BoosterPosition.transform.position, transform.rotation);
            delay = 5;
            sfx.GetComponent<AudioManager>().PlaySFXReference(3);
        }

    }

    void FixedUpdate()
    {
        if (delay > 0) { delay-=Time.fixedDeltaTime; }
        special.transform.localScale = new Vector3(0.66f-0.66f*(delay/5),0.66f,0.66f);
    }
}

