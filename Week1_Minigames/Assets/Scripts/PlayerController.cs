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
    private bool collided = false;
    private GameController1 gamecontroller1;
    public bool isdead = false;
    private Animator playerAnimator;

    private void Awake()
    {
        playerText = transform.Find("PlayerText").GetComponent<TextMesh>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        gamecontroller1 = GameObject.Find("GameController").GetComponent<GameController1>();
        playerAnimator = transform.Find("PlayerSprite").GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        playerText.text = playerNumber + "P";
        //Debug.Log(playerNumber);
    }
	
	// Update is called once per frame
	void Update ()
    {
        isDead();
    }

    private void FixedUpdate()
    {
        playerMovement(playerNumber);
    }

    private void playerMovement(int player)
    {
        float movement = 0.125f;
        float jumpHeight = 5.0f;
        if (collided == false)
        {
            switch (player)
            {
                case 1:
                    if (Input.GetKey(KeyCode.Z))
                    {
                        newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 2);
                    }
                    else if (Input.GetKey(KeyCode.X))
                    {
                        newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 3);
                    }
                    else if (Input.GetKey(KeyCode.S) && grounded == true)
                    {
                        playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                    }
                    else
                    {
                        playerAnimator.SetInteger("anim", 1);
                    }
                    break;
                case 2:
                    if (Input.GetKey(KeyCode.N))
                    {
                        newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 2);
                    }
                    else if (Input.GetKey(KeyCode.M))
                    {
                        newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 3);
                    }
                    else if (Input.GetKey(KeyCode.J) && grounded == true)
                    {
                        playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                    }
                    else
                    {
                        playerAnimator.SetInteger("anim", 1);
                    }
                    break;
                case 3:
                    if (Input.GetKey(KeyCode.Alpha1))
                    {
                        newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 2);
                    }
                    else if (Input.GetKey(KeyCode.Alpha2))
                    {
                        newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 3);
                    }
                    else if (Input.GetKey(KeyCode.Q) && grounded == true)
                    {
                        playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                    }
                    else
                    {
                        playerAnimator.SetInteger("anim", 1);
                    }
                    break;
                case 4:
                    if (Input.GetKey(KeyCode.Alpha8))
                    {
                        newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 2);
                    }
                    else if (Input.GetKey(KeyCode.Alpha9))
                    {
                        newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                        transform.position = newPlayerPosition;
                        playerAnimator.SetInteger("anim", 3);
                    }
                    else if (Input.GetKey(KeyCode.I) && grounded == true)
                    {
                        playerRB.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                    }
                    else
                    {
                        playerAnimator.SetInteger("anim", 1);
                    }
                    break;
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
            collided = true;
            if (collision.contacts[0].point.x > collision.collider.bounds.center.x)
            {
                Vector2 knockbackVelocity = new Vector2(3.5f, 3.5f);
                playerRB.AddForce(knockbackVelocity,ForceMode2D.Impulse);
            }
            else if (collision.contacts[0].point.x < collision.collider.bounds.center.x)
            {
                Vector2 knockbackVelocity = new Vector2(-3.5f, 3.5f);
                playerRB.AddForce(knockbackVelocity,ForceMode2D.Impulse);
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
            Destroy(gameObject);
        }
    }
}
