using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    public float velocity = -0.5f;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player #2");
    }
    void Update()
    {
        var pos = transform.position;
        pos.x += velocity * player.GetComponent<Player2Physics>().direction * Time.deltaTime;
        transform.position = pos;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #1"))
            {
            other.GetComponent<PlayerPhysics>().Hit(25, 10, transform.position);
            Destroy(gameObject);
            }
    }
}

