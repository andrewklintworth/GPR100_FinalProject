using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    public GameObject slash;
    public GameObject BoosterPosition;

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
    }
}

