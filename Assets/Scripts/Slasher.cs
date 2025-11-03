using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasher : MonoBehaviour
{
    public GameObject slash;
    public GameObject BoosterPosition;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            Instantiate(slash, BoosterPosition.transform.position, Quaternion.identity);

    }
}

