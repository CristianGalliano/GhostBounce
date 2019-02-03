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

    private void Awake()
    {
        panel1.gameObject.SetActive(true);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        buttonVisibility = GameObject.Find("ButtonVisibility");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX", 0.25f);
        MusicSlider.value = PlayerPrefs.GetFloat("Music", 0.20f);
    }

    void Start ()
    {
        buttonVisibility.gameObject.SetActive(false);
	}
	
	void Update ()
    {
        exitMultiplayerHover();
        updateSliderText();
        if (panel3.gameObject.activeSelf == true)
        {
            updateAudioValues();
        }
    }

    public void openControls()
    {
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(true);
    }

    public void back()
    {
        panel2.gameObject.SetActive(false);
        panel1.gameObject.SetActive(true);
    }

    public void openSoundSettings()
    {
        panel1.gameObject.SetActive(false);
        panel3.gameObject.SetActive(true);
    }

    public void back2()
    {
        panel3.gameObject.SetActive(false);
        panel1.gameObject.SetActive(true);
    }

    public void startTwoPlayer()
    {
        startMultiplayer(2);
    }

    public void startThreePLayer()
    {
        startMultiplayer(3);
    }

    public void startFourPlayer()
    {
        startMultiplayer(4);
    }

    private void startMultiplayer(int players)
    {
        PlayerPrefs.SetInt("Players", players);
        SceneManager.LoadScene("Multiplayer");
    }

    public void MultiplayerHover()
    {
        if (count == 0)
        {
            buttonVisibility.gameObject.SetActive(true);
            count = 1;
        }
        else if (count == 1)
        {
            buttonVisibility.gameObject.SetActive(false);
            count = 0;
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
        Application.Quit();
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
}
