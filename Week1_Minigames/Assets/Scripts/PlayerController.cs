using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private TextMesh playerText;
    private GameObject player;
    private SpriteRenderer playerSprite;
    private Vector3 newPlayerPosition;
    public Sprite[] sprites;
    public int playerNumber;

    private void Awake()
    {
        playerText = transform.Find("PlayerText").GetComponent<TextMesh>();
        playerSprite = transform.Find("PlayerSprite").GetComponent<SpriteRenderer>();
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
        playerMovement(playerNumber);   
    }

    private void playerMovement(int player)
    {
        float movement = 0.125f; 
        switch (player)
        {
            case 1:
                if (Input.GetKey(KeyCode.Z))
                {
                    newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[2];
                    //Debug.Log("z pressed.");
                }
                else if (Input.GetKey(KeyCode.X))
                {
                    newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[3];
                    //Debug.Log("x pressed.");
                }
                else
                {
                    playerSprite.sprite = sprites[0];
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.N))
                {
                    newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[2];
                    //Debug.Log("z pressed.");
                }
                else if (Input.GetKey(KeyCode.M))
                {
                    newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[3];
                    //Debug.Log("x pressed.");
                }
                else
                {
                    playerSprite.sprite = sprites[0];
                }
                break;
            case 3:
                if (Input.GetKey(KeyCode.Alpha1))
                {
                    newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[2];
                    //Debug.Log("z pressed.");
                }
                else if (Input.GetKey(KeyCode.Alpha2))
                {
                    newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[3];
                    //Debug.Log("x pressed.");
                }
                else
                {
                    playerSprite.sprite = sprites[0];
                }
                break;
            case 4:
                if (Input.GetKey(KeyCode.Alpha8))
                {
                    newPlayerPosition = new Vector3(transform.position.x - movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[2];
                    //Debug.Log("z pressed.");
                }
                else if (Input.GetKey(KeyCode.Alpha9))
                {
                    newPlayerPosition = new Vector3(transform.position.x + movement, transform.position.y, transform.position.z);
                    transform.position = newPlayerPosition;
                    playerSprite.sprite = sprites[3];
                    //Debug.Log("x pressed.");
                }
                else
                {
                    playerSprite.sprite = sprites[0];
                }
                break;
        }
    }
}
