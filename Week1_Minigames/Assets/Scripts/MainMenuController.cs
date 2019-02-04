using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameObject buttonVisibility;
    private int count = 0;
    public GameObject panel1, panel2, panel3;
    public Slider SFXSlider, MusicSlider;
    public Text SFXValue, MusicValue;
    public bool controllerConnected = false;
    private int State = 0;
    public AudioClip coin;
    private AudioSource thisAudiosource;
    private bool nothingPressed = false;

    private void Awake()
    {
        panel1.gameObject.SetActive(true);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        buttonVisibility = GameObject.Find("ButtonVisibility");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX", 0.25f);
        MusicSlider.value = PlayerPrefs.GetFloat("Music", 0.20f);
        thisAudiosource = gameObject.GetComponent<AudioSource>();
    }

    void Start ()
    {
        buttonVisibility.gameObject.SetActive(false);
        if (Input.GetJoystickNames().Length > 0)
        {
            controllerConnected = true;
        }
	}
	
	void Update ()
    {
        exitMultiplayerHover();
        updateSliderText();
        if (panel3.gameObject.activeSelf == true)
        {
            updateAudioValues();
        }
        if (controllerConnected == true)
        {
            controllerInput();
        }
        thisAudiosource.volume = PlayerPrefs.GetFloat("SFX", 0.25f);
    }

    public void openControls()
    {
        playSound();
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(true);
        State = 2;
    }

    public void back()
    {
        playSound();
        panel2.gameObject.SetActive(false);
        panel1.gameObject.SetActive(true);
        State = 0;
    }

    public void openSoundSettings()
    {
        playSound();
        panel1.gameObject.SetActive(false);
        panel3.gameObject.SetActive(true);
        State = 3;
    }

    public void back2()
    {
        playSound();
        panel3.gameObject.SetActive(false);
        panel1.gameObject.SetActive(true);
        State = 0;
    }

    public void startTwoPlayer()
    {
        if (nothingPressed == false)
        {
            playSound();
            StartCoroutine(multiplayerDelay(2));
        }
    }

    public void startThreePLayer()
    {
        if (nothingPressed == false)
        {
            playSound();
            StartCoroutine(multiplayerDelay(3));
        }
    }

    public void startFourPlayer()
    {
        if (nothingPressed == false)
        {
            playSound();
            StartCoroutine(multiplayerDelay(4));
        }
    }

    private void startMultiplayer(int players)
    {
        PlayerPrefs.SetInt("Players", players);
        SceneManager.LoadScene("Multiplayer");
    }

    public void MultiplayerHover()
    {
        playSound();
        if (count == 0)
        {
            buttonVisibility.gameObject.SetActive(true);
            count = 1;
            State = 1;
        }
        else if (count == 1)
        {
            buttonVisibility.gameObject.SetActive(false);
            count = 0;
            State = 0;
        }
    }

    public void exitMultiplayerHover()
    {
        if (Input.GetMouseButton(0) && buttonVisibility.activeSelf == true && !RectTransformUtility.RectangleContainsScreenPoint(buttonVisibility.GetComponent<RectTransform>(), Input.mousePosition, Camera.main))
        {
            buttonVisibility.gameObject.SetActive(false);
            count = 0;
        }
    }

    public void exit()
    {
        if (nothingPressed == false)
        {
            playSound();
            StartCoroutine("exitDelay");
        }
    }

    private void updateSliderText()
    {
        SFXValue.text = SFXSlider.value.ToString();
        MusicValue.text = MusicSlider.value.ToString();
    }

    private void updateAudioValues()
    {
        PlayerPrefs.SetFloat("SFX", SFXSlider.value);
        PlayerPrefs.SetFloat("Music", MusicSlider.value);
    }

    public void controllerInput()
    {
        switch (State)
        {
            case 0:
                if (Input.GetButtonDown("globalX"))
                {
                    MultiplayerHover();
                }
                if (Input.GetButtonDown("globalSquare"))
                {
                    openControls();
                }
                if (Input.GetButtonDown("globalTriangle"))
                {
                    openSoundSettings();
                }
                if (Input.GetButtonDown("globalCircle"))
                {
                    exit();
                }
                break;
            case 1:
                if (Input.GetButtonDown("globalX"))
                {
                    startTwoPlayer();
                }
                if (Input.GetButtonDown("globalSquare"))
                {
                    startThreePLayer();
                }
                if (Input.GetButtonDown("globalTriangle"))
                {
                    startFourPlayer();
                }
                if (Input.GetButtonDown("globalCircle"))
                {
                    MultiplayerHover();
                }
                break;
            case 2:
                if (Input.GetButtonDown("globalX") || Input.GetButtonDown("globalCircle"))
                {
                    back();
                }
                break;
            case 3:
                if (Input.GetButtonDown("globalX") || Input.GetButtonDown("globalCircle"))
                {
                    back2();
                }
                break;
        }
    }

    void playSound()
    {
        thisAudiosource.PlayOneShot(coin);
    }

    private IEnumerator multiplayerDelay(int i)
    {
        nothingPressed = true;
        yield return new WaitForSeconds(coin.length);
        startMultiplayer(i);
    }

    private IEnumerator exitDelay()
    {
        nothingPressed = true;
        yield return new WaitForSeconds(coin.length);
        Application.Quit();
    }
}
