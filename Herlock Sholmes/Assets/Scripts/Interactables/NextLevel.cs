using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : Interactable
{

    public string sceneName;

    public override void PerformAction()
    {
        SceneManager.LoadScene(sceneName);
    }

    public override void UnPerformAction()
    {
    }
}
