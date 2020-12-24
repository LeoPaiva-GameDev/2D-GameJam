using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("Story");
        Debug.Log("ae carai");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Continue()
    {
        SceneManager.LoadScene("LevelOne");
    }

    public void ReadyOne()
    {
        SceneManager.LoadScene("BossOne");
    }

    public void ReadyTwo()
    {
        SceneManager.LoadScene("BossTwo");
    }

    public void ReadyThree()
    {
        SceneManager.LoadScene("BossThree");
    }

    public void ReadyFour()
    {
        SceneManager.LoadScene("AllBosses");
    }

    public void ContinueOne()
    {
        SceneManager.LoadScene("LevelTwo");
    }

    public void ContinueTwo()
    {
        SceneManager.LoadScene("LevelThree");
    }

    public void Final()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
