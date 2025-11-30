using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sheild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("die",0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(2f*Time.deltaTime,2f*Time.deltaTime,0);
    }

    void die()
    {
        Destroy(gameObject);
    }
}
