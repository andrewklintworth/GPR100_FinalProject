using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Player2Physics : MonoBehaviour
{
    //public
    public GameObject hitVisual;
    public GameObjectList[] playerInfo;
    public Sprite[] textures;
    public Rigidbody PlayerRB;
    public GameObject otherPlayer;
    public float horizontalSpeed = 0;
    public GameObject healthBar;
    public int jumpHeight = 0;
    public float maxSpeed = 0;
    public int direction = 1;

    //private/not public
    GameObject basicHit;
    GameObject basicHitAir;
    float timerFixedUpdate = 2;
    float hitCooldown = 0;
    float hitStun = 0;
    float maxHealth = 160;
    int Health = 160;
    int characterNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("MenuManager")) { characterNum = GameObject.Find("MenuManager").GetComponent<MenuManagerScript>().p2CharacterNum; }

        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = textures[characterNum];
        basicHit = playerInfo[characterNum].gameObjects[0];
        basicHitAir = playerInfo[characterNum].gameObjects[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < otherPlayer.transform.position.x)
        { transform.rotation = new Quaternion(0, 0, 0, 0); direction = 1; }
        else { transform.rotation = new Quaternion(0, 180, 0, 0); direction = -1; }
    }

    void FixedUpdate()
    {
        if (timerFixedUpdate > 0) { timerFixedUpdate-=Time.fixedDeltaTime; }
        if (hitCooldown > 0) { hitCooldown -= Time.fixedDeltaTime; }
        if (hitStun > 0) { hitStun -= Time.fixedDeltaTime; } else { hitVisual.GetComponent<MeshRenderer>().enabled = false; }

        Movement();

    }

    void Movement()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, Vector3.down, out hitinfo, 1.6f) && hitStun <= 0)
        {

            if (Input.GetKey(KeyCode.L) && hitCooldown <= 0)
            {
                Vector3 offset = basicHit.transform.position;
                Instantiate(basicHit, transform.position + new Vector3(offset.x*direction,offset.y,offset.z), transform.rotation, gameObject.transform);
                hitCooldown = 1.5f;
            }

            // Right/Left movement
            if (Input.GetKey(KeyCode.LeftArrow)) { PlayerRB.AddForce(new Vector3(-horizontalSpeed, 0, 0)); }
            if (Input.GetKey(KeyCode.RightArrow)) { PlayerRB.AddForce(new Vector3(horizontalSpeed, 0, 0)); }

            // Clamp velocity Right/Left/Up/Down
            PlayerRB.velocity = new Vector3(Mathf.Clamp(PlayerRB.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(PlayerRB.velocity.y, -20, 10000), 0);

            // Jumping
            if (hitinfo.collider.gameObject.layer == 6 && Input.GetKey(KeyCode.UpArrow) && timerFixedUpdate <= 0)
            {
                timerFixedUpdate = 0.2f;
                PlayerRB.AddForce(new Vector3(0, jumpHeight, 0));
            }
        }
        else if (hitStun <= 0)
        {
            if (Input.GetKey(KeyCode.L) && hitCooldown <= 0)
            {
                Vector3 offset = basicHitAir.transform.position;
                Instantiate(basicHitAir, transform.position + new Vector3(offset.x*direction,offset.y,offset.z), transform.rotation, gameObject.transform);
                hitCooldown = 1.5f;
            }
        }
    }

    public void Hit(int damage, int force, /*Vector3 Direction*/Vector3 location)
    {
        hitVisual.GetComponent<MeshRenderer>().enabled = true;
        hitStun = 0.6f;
        Health -= damage;

        healthBar.transform.localScale = new Vector3(Health / maxHealth, 1, 1);
        //PlayerRB.AddForce(new Vector3(Direction.x * -direction *force,Direction.y * force,0), ForceMode.Impulse);
        PlayerRB.AddForce((transform.position-location).normalized*force, ForceMode.Impulse);
        if (Health <= 0) { SceneManager.LoadScene("Menu"); }
    }

}
