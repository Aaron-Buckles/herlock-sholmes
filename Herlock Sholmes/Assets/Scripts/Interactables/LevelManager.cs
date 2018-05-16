using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Interactable
{

    public GameObject nextLevelPanel;
    public string sceneName;

    void Start()
    {
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
}
