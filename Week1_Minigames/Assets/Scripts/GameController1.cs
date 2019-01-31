using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour
{
    private Text timerText;
    public int count;
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
        playerCount = PlayerPrefs.GetInt("Players", 0);
    }

    void Start()
    {
        StartCoroutine("timer", count);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeOver == false)
        {
            allDead();
        }
    }

    private IEnumerator timer(int sR)
    {       
        for (int i = 0; i < count+1; i++)
        {
            timerText.text = sR + " Seconds";
            sR--;
            yield return new WaitForSeconds(1.0f);
        }
        timerText.text = "";
        timeOver = true;
        endScreen.gameObject.SetActive(true);
    }

    private void allDead()
    {
        if (playerCount == 1)
        {
            StopAllCoroutines();
            gameOverText.text += ", " + players[0] + " Wins!";
            endScreen.gameObject.SetActive(true);
            playerCount--;
        }
    }

    public void restartMP()
    {
        SceneManager.LoadScene("Multiplayer");
    }
}
