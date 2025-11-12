using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitBoxHitP2 : MonoBehaviour
{
    bool player1 = false;
    void Awake()
    {
        if (transform.parent.name.Equals("Player #1")) { player1 = true; }
    }
    public int pushForce;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (player1 && other.name.Equals("Player #1"))
        {
            hit(other);
        }
        else if(other.name.Equals("Player #2"))
        {
            hit(other);
        }
    }
    void hit(Collider other)
    {
        other.GetComponent<PlayerPhysics>().Hit(20, pushForce, transform.position);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        //gameObject.GetComponentInParent<HitBoxMove>().destroySelf();
    }
}
