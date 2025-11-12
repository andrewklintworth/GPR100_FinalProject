using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitBoxHit : MonoBehaviour
{
    bool player1 = false;
    void Start()
    {
        if (transform.parent.parent.name.Equals("Player #1")) { player1 = true; }
    }
    public int pushForce;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (player1 && other.name.Equals("Player #2"))
        {
            other.GetComponent<Player2Physics>().Hit(20, pushForce, transform.position);
            hit(other);
        }
        else if (!player1 && other.name.Equals("Player #1"))
        {
            other.GetComponent<PlayerPhysics>().Hit(20, pushForce, transform.position);
            hit(other);
        }
    }
    
    void hit(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //gameObject.GetComponentInParent<HitBoxMove>().destroySelf();
    }
}
