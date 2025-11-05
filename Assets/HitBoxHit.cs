using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxHit : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Player #2"))
        {
            other.GetComponent<Player2Physics>().Hit(20, 500, transform.position);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //gameObject.GetComponentInParent<HitBoxMove>().destroySelf();
        }
    }
}
