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
    private bool timeOver = false;
    // Start is called before the first frame update

    private void Awake()
    {
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        endScreen.gameObject.SetActive(false);
        playerCount = PlayerPrefs.GetInt("Players", 2);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOver == false)
        {
            allDead();
        }
        timer();
    }

    private void timer()
    {
        count -= Time.deltaTime;        
        timerText.text = (int)count + " Seconds";
        if (count <= 0)
        {
            timerText.text = "";
            timeOver = true;
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
            gameOverText.text = "Game Over, " + players[0] + " Wins!";
            endScreen.gameObject.SetActive(true);
            playerCount--;
        }
    }

    public void restartMP()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
