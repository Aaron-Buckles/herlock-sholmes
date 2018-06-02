using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [Tooltip("Element 0 should be the main menu")]
    public GameObject continueGameButton;
    public GameObject[] menues;

    void Start()
    {
        try
        {
            OpenMenu(0);
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("Index out of range");
        }

        if (!PlayerPrefs.HasKey("Level"))
        {
            continueGameButton.gameObject.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenMenu(int menuIndex)
    {
        foreach (GameObject menu in menues)
        {
            menu.SetActive(false);
        }

        menues[menuIndex].SetActive(true);
        Button[] buttons = menues[menuIndex].GetComponentsInChildren<Button>(true);
        buttons[0].Select();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
