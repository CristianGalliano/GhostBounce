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
    public int playerCount;
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
        allDead();
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
        endScreen.gameObject.SetActive(true);
    }

    private void allDead()
    {
        if (playerCount == 0)
        {
            StopAllCoroutines();
            timerText.text = "";
            endScreen.gameObject.SetActive(true);
        }
    }
}
