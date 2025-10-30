using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float velocity = 0.1f;
    void Update()
    {
        var pos = transform.position;
        pos.x += velocity * Time.deltaTime;
        transform.position = pos;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #2")) 
            {
            other.GetComponent<Player2Physics>().Hit();
            Destroy(gameObject); 
            }
    }
}
