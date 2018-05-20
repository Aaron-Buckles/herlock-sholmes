using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Interactable
{

    public GameObject nextLevelPanel;
    public GameObject[] starUI;
    public string sceneName;
    [Space]
    public GameObject pauseMenuPanel;

    int starsCollected;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        starsCollected = 0;

        nextLevelPanel.SetActive(false);
        foreach (GameObject star in starUI)
        {
            star.SetActive(false);
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

    public void StarCollected(int starNumber)
    {
        try
        {
            starUI[starNumber].SetActive(true);
            starsCollected++;
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("There should only be three stars in the scene");
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
