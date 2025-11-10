using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerPhysics : MonoBehaviour
{
    //public
    public GameObject hitVisual;
    public GameObject basicHit;
    public GameObject basicHitAir;
    public Rigidbody PlayerRB;
    public GameObject otherPlayer;
    public float horizontalSpeed = 0;
    public GameObject healthBar;
    public int jumpHeight = 0;
    public float maxSpeed = 0;

    //private/not public
    int timerFixedUpdate = 2;
    int hitCooldown = 0;
    int hitStun = 0;
    float maxHealth = 160;
    int Health = 160;
    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > otherPlayer.transform.position.x)
        { transform.rotation = new Quaternion(0, 180, 0, 0); direction = -1; }
        else { transform.rotation = new Quaternion(0, 0, 0, 0); direction = 1;}
    }

    void FixedUpdate()
    {
        if (timerFixedUpdate > 0) { timerFixedUpdate--; }
        if (hitCooldown > 0) { hitCooldown--; }
        if (hitStun > 0) { hitStun--; } else { hitVisual.GetComponent<MeshRenderer>().enabled = false; }

        Movement();


    }
    
    void Movement()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitinfo, 1.6f) && hitStun == 0)
        {

            if (Input.GetKey(KeyCode.C) && hitCooldown == 0)
            {
                Instantiate(basicHit, transform.position + new Vector3(0.6f*direction, -0.5f, 0), transform.rotation, gameObject.transform);
                hitCooldown = 60;
            }

            // Right/Left movement
            if (Input.GetKey(KeyCode.A)) { PlayerRB.AddForce(new Vector3(-horizontalSpeed, 0, 0)); }
            if (Input.GetKey(KeyCode.D)) { PlayerRB.AddForce(new Vector3(horizontalSpeed, 0, 0)); }

            // Clamp velocity Right/Left/Up/Down
            PlayerRB.velocity = new Vector3(Mathf.Clamp(PlayerRB.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(PlayerRB.velocity.y, -20, 10000), 0);

            // Jumping
            if (hitinfo.collider.gameObject.layer == 6 && Input.GetKey(KeyCode.W) && timerFixedUpdate == 0)
            {
                timerFixedUpdate = 2;
                PlayerRB.AddForce(new Vector3(0, jumpHeight, 0));
            }
        }
        else if (hitStun == 0)
        {
            if (Input.GetKey(KeyCode.C) && hitCooldown == 0)
            {
                Instantiate(basicHitAir, transform.position + new Vector3(0, -1, 0), transform.rotation, gameObject.transform);
                hitCooldown = 60;
            }
        }
    }

    public void Hit(int damage, int force, Vector3 location)
    {
        hitVisual.GetComponent<MeshRenderer>().enabled = true;
        hitStun = 30;
        Health -= damage;

        healthBar.transform.localScale = new Vector3(Health / maxHealth, 1, 1);
        PlayerRB.AddForce((transform.position - location).normalized * force, ForceMode.Impulse);
        if (Health <= 0) { SceneManager.LoadScene("Menu"); }

        Debug.Log("Hit");
    }

}
