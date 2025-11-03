using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    public float velocity = -0.5f;
    void Update()
    {
        var pos = transform.position;
        pos.x += velocity * Time.deltaTime;
        transform.position = pos;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #1"))
            {
            other.GetComponent<PlayerPhysics>().Hit(35, 100, transform.position);
            Destroy(gameObject);
            }
    }
}

