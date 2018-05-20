using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [Tooltip("Element 0 should be the main menu")]
    public GameObject[] menues;

    public GameObject mainMenuMask;

    void Awake()
    {
        mainMenuMask.SetActive(true);
    }

    void Start()
    {
        // This try block is temporary
        try
        {
            OpenMenu(0);
        }
        catch (System.IndexOutOfRangeException)
        {
            Debug.Log("Index out of range");
        }

        mainMenuMask.GetComponent<Image>().CrossFadeAlpha(0f, 2.0f, false);
    }


    public void ContinueGame()
    {
        // This is temporary
        SceneManager.LoadScene(1);
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
