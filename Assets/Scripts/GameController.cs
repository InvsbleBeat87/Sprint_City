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
    public static float Timer = 75f;
    public PlayerBehavior PlayerBehaviorInstance;
    public GameObject winText;
    public GameObject loseText;

    // Start is called before the first frame update

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level01")
        {
            Time.timeScale = 1;
            timerText.text = Timer.ToString("Time: 75");
        }

        if (scene.name == "Level02")
        {
            Time.timeScale = 1;
            timerText.text = Timer.ToString("Time: 75");
        }

        if (scene.name == "Level03")
        {
            Time.timeScale = 1;
            timerText.text = Timer.ToString("Time: 75");
        }
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
    
        Timer -= Time.deltaTime;
        timerText.text = "Time: " + Timer;
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
