using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPhysics : MonoBehaviour
{
    //public RigidBody;
    public Rigidbody PlayerRB;
    public float horizontalSpeed = 0;
    public int jumpHeight = 0;
    public float maxSpeed = 0;
    RaycastHit isGrounded;


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
        // Right/Left movement
        if (Input.GetKey(KeyCode.A)){ PlayerRB.AddForce(new Vector3(-horizontalSpeed, 0, 0)); }
        if (Input.GetKey(KeyCode.D)){ PlayerRB.AddForce(new Vector3(horizontalSpeed, 0, 0)); }
        // Clamp velocity Right/Left/Up/Down
        PlayerRB.velocity=new Vector3(Mathf.Clamp(PlayerRB.velocity.x,-maxSpeed,maxSpeed),Mathf.Clamp(PlayerRB.velocity.y,-20,10000),0);
        // Jumping
        Physics.SphereCast(transform.position, 1, Vector3.down, out isGrounded);
        if (isGrounded.collider.name.Equals("Floor")&& Input.GetKey(KeyCode.W)) { PlayerRB.AddForce(new Vector3(0, jumpHeight, 0));}
        

    }

}
