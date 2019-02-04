using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    private Text timerText;
    public float count;
    public GameObject endScreen;
    public Text gameOverText;
    public int playerCount;
    public List <string> players = new List<string> { "Player 1", "Player 2", "Player 3", "Player 4" };
    public bool gameOver = false;
    public bool controllerConnected = false;
    public Text restart, quit;
    private AudioSource thisAudiosource;
    public AudioClip coin;
    private bool nothingPressed = false;
    // Start is called before the first frame update

    private void Awake()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        endScreen.gameObject.SetActive(false);
        playerCount = PlayerPrefs.GetInt("Players", 2);
        thisAudiosource = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        foreach (string name in Input.GetJoystickNames())
        {
            Debug.Log(name);
        }
        if (Input.GetJoystickNames().Length > 0)
        {
            controllerConnected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            allDead();
        }
        controllerControls();
        timer();
    }

    private void timer()
    {
        count -= Time.deltaTime;        
        timerText.text = (int)count + " Seconds";
        if (count <= 0)
        {
            timerText.text = "";
            gameOver = true;
            endScreen.gameObject.SetActive(true);
        }
        if ((int)count <= 15 && (int)count > 10)
        {
            timerText.color = Color.yellow;
        }
        else if ((int)count <= 10 && (int)count > 5)
        {
            timerText.color = new Color(1, 0.5f, 0);
        }
        else if ((int)count <= 5)
        {
            timerText.color = Color.red;
        }
    }

    private void allDead()
    {
        if (playerCount == 1)
        {
            StopAllCoroutines();
            gameOver = true;
            gameOverText.text = "Game Over, " + players[0] + " Wins!";
            if (controllerConnected == true)
            {
                restart.text = restart.text + "/X";
                quit.text = quit.text + "/O";
            }
            endScreen.gameObject.SetActive(true);
            playerCount--;
        }
    }

    public void restartMP()
    {
        if (nothingPressed == false)
        {
            thisAudiosource.PlayOneShot(coin);
            StartCoroutine(delay("Multiplayer"));
        }
    }

    public void backToMainMenu()
    {
        if (nothingPressed == false)
        {
            thisAudiosource.PlayOneShot(coin);
            StartCoroutine(delay("Main_Menu"));
        }
    }

    private void controllerControls()
    {
        if (gameOver == true)
        {
            if (Input.GetButtonDown("restart"))
            {
                restartMP();
            }
            if (Input.GetButtonDown("quit"))
            {
                backToMainMenu();
            }
        }
    }

    public IEnumerator delay(string name)
    {
        nothingPressed = true;
        yield return new WaitForSeconds(coin.length);
        SceneManager.LoadScene(name);
    }
}
