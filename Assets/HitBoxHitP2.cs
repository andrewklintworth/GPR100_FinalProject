using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHitP2 : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #1"))
        {
            other.GetComponent<PlayerPhysics>().Hit(20, 400, transform.position);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //gameObject.GetComponentInParent<HitBoxMove>().destroySelf();
        }
    }
}
