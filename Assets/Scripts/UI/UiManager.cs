using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;    
    public GameObject PlaySprite;
    public TMP_Text CoinCount;
    public TMP_Text TimeCounter;       
    public GameObject menu;
    public GameObject PlayPauseButton;
    public GameObject GameOver;
    public GameObject GameWin;
    public GameObject WelcomeMessage;
    public GameObject AndroidButtons;

    private float timeCount = 400f;
    private bool isPlayPause;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WelcomeMessageDelay());
        if (Application.platform == RuntimePlatform.Android)
        {
            // Activate the button for Android devices
            AndroidButtons.SetActive(true);
        }
        else
        {
            // Deactivate the button for non-Android devices
            AndroidButtons.SetActive(false);
        }

    }
    IEnumerator WelcomeMessageDelay()
    {
        yield return new WaitForSeconds(2f);
        WelcomeMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            TimeCounter.SetText("Time: " + ((int)timeCount).ToString());
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void LeftArrowButton()
    {
        
    }
    public void RightArrowButton() {}
    public void UpArrowButton() {  }
    public void DownArrowButton() {  }
    public void Menu()
    {
      
        if (!isPlayPause)
        {
            menu.transform.GetChild(0).gameObject.SetActive(true);
            Time.timeScale = 0;
            isPlayPause = !isPlayPause;
            PlayPauseButton.SetActive(false);
        }
        else
        {
            menu.transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1;
            isPlayPause = !isPlayPause;
            PlayPauseButton.SetActive(true);
        }
    }
    public void MenuPlay()
    {
        Time.timeScale = 1;
        menu.transform.GetChild(0).gameObject.SetActive(false);
        isPlayPause = !isPlayPause;
        PlayPauseButton.SetActive(true);
    }
    public void MenuReset()
    {
        SceneManager.LoadScene(0);
    }
    public void MenuExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

        

    }
    public void GameOverFun()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
        menu.SetActive(false);
        PlayPauseButton.SetActive(false);
    }
    public void GameWon()
    {
        Time.timeScale = 0f;
        GameWin.SetActive(true);
        menu.SetActive(false);
        PlayPauseButton.SetActive(false);

    }
    public void PlayAndPause()
    {
        
        if (!isPlayPause)
        {
            PlaySprite.SetActive(true);
            Time.timeScale = 0;
            isPlayPause = !isPlayPause;
            menu.SetActive(false);
        }
        else
        {
            PlaySprite.SetActive(false);
            Time.timeScale = 1;
            isPlayPause = !isPlayPause;
            menu.SetActive(true);
        }
    }
    
}
