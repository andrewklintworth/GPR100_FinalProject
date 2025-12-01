using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject player;
    public float velocity = 0.5f;

    void Start()
    {
        player = GameObject.Find("Player #1");
    }
    void Update()
    {
        var pos = transform.position;
        pos.x += velocity * player.GetComponent<PlayerPhysics>().direction * Time.deltaTime;
        transform.position = pos;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #2")) 
            {
            other.GetComponent<Player2Physics>().Hit(25,10,transform.position);
            Destroy(gameObject); 
            }
    }
}
