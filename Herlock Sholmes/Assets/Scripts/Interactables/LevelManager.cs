using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Interactable
{

    public GameObject nextLevelPanel;
    public GameObject[] coinUI;
    public string sceneName;
    [Space]
    public GameObject pauseMenuPanel;

    int coinsCollected;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        coinsCollected = 0;

        nextLevelPanel.SetActive(false);
        foreach (GameObject coin in coinUI)
        {
            coin.SetActive(false);
        }

        pauseMenuPanel.SetActive(false);
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Cancel"))
        {
            Pause();
        }
    }

    public override void PerformAction()
    {
        Cursor.visible = true;
        nextLevelPanel.SetActive(true);

        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
            PlayerPrefs.DeleteKey("Level");
        else
            PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex + 1);
    }

    public override void UnPerformAction()
    {
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextButton()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void CoinCollected(int coinNumber)
    {
        try
        {
            coinUI[coinNumber].SetActive(true);
            coinsCollected++;
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("There should only be three coins in the scene");
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        pauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        pauseMenuPanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
