using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TMP_Text livesText;
    public int Lives;
    public TMP_Text timerText;
    public static float Timer = 60f;
    public PlayerBehavior PlayerBehaviorInstance;
    public GameObject winText;
    public GameObject loseText;
    public GameObject returnText;

    // Start is called before the first frame update
    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;
        Timer = 60;
    }

    public void UpdateLives()
    {
        Lives -= 1;
        livesText.text = "Lives: " + Lives;
        if (Lives == 0)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        StopGame();
        loseText.SetActive(true);
        returnText.SetActive(true);
        PauseTimer();
    }

    public void WinLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void WinGame()
    {
        StopGame();
        winText.SetActive(true);
        returnText.SetActive(true);
        PauseTimer();
    }

    public void StopGame()
    {
        PlayerBehaviorInstance.speed = 0;
    }

    public void PauseTimer()
    {
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (timerText != null)
        {
            Timer -= Time.deltaTime;
            timerText.text = "Time: " + Timer;
        }
        if(Timer < 0)
        {
            LoseGame();
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if(Input.GetKey(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(0);
        }
    }
}
