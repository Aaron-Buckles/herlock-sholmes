using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Interactable
{

    public GameObject nextLevelPanel;
    public string sceneName;

    GameObject[] starUI;
    int starsCollected = 0;

    void Start()
    {
        starUI = GameObject.FindGameObjectsWithTag("StarUI");
        foreach (GameObject star in starUI)
        {
            star.SetActive(false);
        }

        Cursor.visible = false;
        nextLevelPanel.SetActive(false);
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

    public void StarCollected()
    {
        try
        {
            starUI[starsCollected++].SetActive(true);
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("There should only be three stars in the scene");
        }
    }
}
