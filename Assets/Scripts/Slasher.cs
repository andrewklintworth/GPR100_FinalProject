using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    public GameObject slash;
    public GameObject BoosterPosition;
    public GameObject special;

    int delay = 0;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K) && delay == 0)
        {
            Instantiate(slash, BoosterPosition.transform.position, transform.rotation);
            delay = 400;
        }

    }

    void FixedUpdate()
    {
        if (delay > 0) { delay--; }
        special.transform.localScale = new Vector3(0.66f-0.66f*(delay/400f),0.66f,0.66f);
    }
}

