using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TextMesh playerText;
    private GameObject player;
    private Vector3 newPlayerPosition;
    public int playerNumber;
    private Rigidbody2D playerRB;
    private bool grounded = false;
    private int canMove = 0;
    private bool collided = false;
    private GameController1 gamecontroller1;
    public bool isdead = false;
    private Animator playerAnimator;
    private SpriteRenderer playerSprite;
    private bool inGhostMode = false;
    private Color norm;
    private Color tmp;
    public ParticleSystem deathParticle;
    public ParticleSystem bounceParticle;
    private bool canGhostMode = true;
    float leftStick1, leftStick2, leftStick3, leftStick4;


    private void Awake()
    {
        playerText = transform.Find("PlayerText").GetComponent<TextMesh>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        gamecontroller1 = GameObject.Find("GameController").GetComponent<GameController1>();
        playerAnimator = transform.Find("PlayerSprite").GetComponent<Animator>();
        playerSprite = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        tmp = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.25f);
        norm = playerSprite.color;
    }

    // Use this for initialization
    void Start ()
    {
        playerText.text = playerNumber + "P";
    }
	
	// Update is called once per frame
	void Update ()
    {
        isDead();
        if (canMove == 0)
        {
            if (grounded == true)
            {
                canMove = 1;
            }
        }
        if (grounded == false)
        {
            playerAnimator.SetInteger("anim", 5);
        }
        GhostMode();
        leftStick1 = Input.GetAxis("player1_move");
        leftStick2 = Input.GetAxis("player2_move");
        leftStick3 = Input.GetAxis("player3_move");
        leftStick4 = Input.GetAxis("player4_move");
        foreach (string name in Input.GetJoystickNames())
        {
            Debug.Log(name);
        }

    }

    private void FixedUpdate()
    {
        playerMovement(playerNumber);
    }

    private void playerMovement(int player)
    {
        float movement = 0.125f;
        float jumpHeight = 7.0f;
        if (collided == false)
        {
            if (canMove == 1)
            {
                switch (player)
                {
                    case 1:
                        if (Input.GetKey(KeyCode.Z) || leftStick1 < 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 2);
                        }
                        else if (Input.GetKey(KeyCode.X) || leftStick1 > 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 3);
                        }
                        else
                        {
                            playerAnimator.SetInteger("anim", 1);
                        }
                        if (Input.GetKeyDown(KeyCode.S) && grounded == true || Input.GetButtonDown("player1_jump") && grounded == true)
                        {
                            playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                        }
                        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("player1_ghostmode"))
                        {
                            if (canGhostMode == true)
                            {
                                StartCoroutine("enableGhostMode");
                                canGhostMode = false;
                            }
                        }
                        break;
                    case 2:
                        if (Input.GetKey(KeyCode.N) || leftStick2 < 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 2);
                        }
                        else if (Input.GetKey(KeyCode.M) || leftStick2 > 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 3);
                        }
                        else
                        {
                            playerAnimator.SetInteger("anim", 1);
                        }
                        if (Input.GetKeyDown(KeyCode.J) && grounded == true || Input.GetButtonDown("player2_jump") && grounded == true)
                        {
                            playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                        }
                        if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("player2_ghostmode"))
                        {
                            if (canGhostMode == true)
                            {
                                StartCoroutine("enableGhostMode");
                                canGhostMode = false;
                            }
                        }
                        break;
                    case 3:
                        if (Input.GetKey(KeyCode.Alpha2) || leftStick3 < 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 2);
                        }
                        else if (Input.GetKey(KeyCode.Alpha1) || leftStick3 > 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 3);
                        }
                        else
                        {
                            playerAnimator.SetInteger("anim", 1);
                        }
                        if (Input.GetKeyDown(KeyCode.W) && grounded == true || Input.GetButtonDown("player3_jump") && grounded == true)
                        {
                            playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                        }
                        if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("player3_ghostmode"))
                        {
                            if (canGhostMode == true)
                            {
                                StartCoroutine("enableGhostMode");
                                canGhostMode = false;
                            }
                        }
                        break;
                    case 4:
                        if (Input.GetKey(KeyCode.Alpha9) || leftStick4 < 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 2);
                        }
                        else if (Input.GetKey(KeyCode.Alpha8) || leftStick4 > 0)
                        {
                            newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                            transform.position = newPlayerPosition;
                            playerAnimator.SetInteger("anim", 3);
                        }
                        else
                        {
                            playerAnimator.SetInteger("anim", 1);
                        }
                        if (Input.GetKeyDown(KeyCode.O) && grounded == true || Input.GetButtonDown("player4_jump") && grounded == true)
                        {
                            playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                        }
                        if (Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("player4_ghostmode"))
                        {
                            if (canGhostMode == true)
                            {
                                StartCoroutine("enableGhostMode");
                                canGhostMode = false;
                            }
                        }
                        break;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            collided = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            switch (inGhostMode)
            {
                case true:
                    break;
                case false:
                    playerSprite.color = norm;
                    collidedWithPlayer(collision);
                    break;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void isDead()
    {
        if (transform.position.y <= -5.0f)
        {
            isdead = true;
        }
        if (isdead == true)
        {
            gamecontroller1.playerCount--;
            gamecontroller1.players.Remove("Player " + playerNumber);
            Instantiate(deathParticle, new Vector3(transform.position.x, -5.0f, transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void collidedWithPlayer(Collision2D collision)
    {
        collided = true;
        Instantiate(bounceParticle, new Vector3(collision.contacts[0].point.x, collision.collider.bounds.center.y, 0), Quaternion.identity);
        if (collision.contacts[0].point.x > collision.collider.bounds.center.x)
        {
            Vector2 knockbackVelocity = new Vector2(3.5f, 3.5f);
            playerRB.AddForce(knockbackVelocity, ForceMode2D.Impulse);
        }
        else if (collision.contacts[0].point.x < collision.collider.bounds.center.x)
        {
            Vector2 knockbackVelocity = new Vector2(-3.5f, 3.5f);
            playerRB.AddForce(knockbackVelocity, ForceMode2D.Impulse);
        }
    }

    private IEnumerator enableGhostMode()
    {
        inGhostMode = true;
        yield return new WaitForSeconds(5.0f);
        inGhostMode = false;
    }

    private void GhostMode()
    {
        if (inGhostMode == true)
        {
            gameObject.layer = 10;
            foreach (Transform children in transform)
            {
                children.gameObject.layer = 10;
            }
            playerSprite.color = tmp;
        }
        else
        {
            gameObject.layer = 9;
            foreach (Transform children in transform)
            {
                children.gameObject.layer = 9;
            }
            playerSprite.color = norm;
        }
    }
}
