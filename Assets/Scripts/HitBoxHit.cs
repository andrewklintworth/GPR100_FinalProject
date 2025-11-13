using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitBoxHit : MonoBehaviour
{
    bool active = false;
    bool player1 = false;
    void Start()
    {
        if (transform.parent.parent.GetComponent<LineRenderer>() && transform.parent.parent.parent.name.Equals("Player #1")) { player1 = true; }
        if (transform.parent.parent.name.Equals("Player #1")) { player1 = true; }
        Invoke("canHit", 0.01f);
    }
    public int pushForce;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (active && player1 && other.name.Equals("Player #2"))
        {
            Vector3 retrivedDirection = transform.parent.GetComponent<HitBoxMove>().retreiveDirection();
            other.GetComponent<Player2Physics>().Hit(20, pushForce, transform.position);
            hit();
        }
        else if (!player1 && other.name.Equals("Player #1"))
        {
            Vector3 retrivedDirection = transform.parent.GetComponent<HitBoxMove>().retreiveDirection();
            other.GetComponent<PlayerPhysics>().Hit(20, pushForce, transform.position);
            hit();
        }
    }
    
    void canHit()
    {
        active = true;
    }

    void hit()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //gameObject.GetComponentInParent<HitBoxMove>().destroySelf();
    }
}
