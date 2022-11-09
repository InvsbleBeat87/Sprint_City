using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayLevel01()
    {
        Debug.Log("Start Level01");
        SceneManager.LoadScene(1);
    }

    public void PlayLevel02()
    {
        Debug.Log("Start Level02");
        SceneManager.LoadScene(2);
    }

    public void PlayLevel03()
    {
        Debug.Log("Start Level03");
        SceneManager.LoadScene(3);
    }

    public void PlayLevel04()
    {
        Debug.Log("Start Level04");
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
