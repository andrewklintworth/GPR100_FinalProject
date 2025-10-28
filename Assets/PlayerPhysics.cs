using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPhysics : MonoBehaviour
{
    //public RigidBody;
    public Rigidbody PlayerRB;
    public float horizontalSpeed = 0;
    public int jumpHeight = 0;
    public float maxSpeed = 0;
    int timerFixedUpdate = 2;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (timerFixedUpdate > 0) { timerFixedUpdate--; }

      
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitinfo, 1.6f)) {
            // Right/Left movement
            if (Input.GetKey(KeyCode.A)) { PlayerRB.AddForce(new Vector3(-horizontalSpeed, 0, 0)); }
            if (Input.GetKey(KeyCode.D)) { PlayerRB.AddForce(new Vector3(horizontalSpeed, 0, 0)); }

            // Clamp velocity Right/Left/Up/Down
            PlayerRB.velocity = new Vector3(Mathf.Clamp(PlayerRB.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(PlayerRB.velocity.y, -20, 10000), 0);

            // Jumping
            if (hitinfo.collider.gameObject.layer == 6 && Input.GetKey(KeyCode.W)&&timerFixedUpdate==0)
            {
                timerFixedUpdate = 2;
                PlayerRB.AddForce(new Vector3(0, jumpHeight, 0));
            }
        } 

        
    }

}
