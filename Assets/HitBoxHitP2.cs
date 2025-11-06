using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitBoxHitP2 : MonoBehaviour
{
    public int pushForce;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #1"))
        {
            other.GetComponent<PlayerPhysics>().Hit(20, pushForce, transform.position);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //gameObject.GetComponentInParent<HitBoxMove>().destroySelf();
        }
    }
}
