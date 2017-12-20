using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [Tooltip("Element 0 should be the main menu")]
    public GameObject[] menues;

    
    void Start()
    {
        // This try block is temporary
        try
        {
            OpenMenu(0);
        }
        catch(System.IndexOutOfRangeException)
        {
            Debug.Log("Index out of range");
        }
    }


    public void ContinueGame()
    {
        // This is temporary
        SceneManager.LoadScene(2);
    }


    public void OpenMenu(int menuIndex)
    {
        foreach(GameObject menu in menues)
        {
            menu.SetActive(false);
        }

        menues[menuIndex].SetActive(true);
    }


    public void QuitGame()
    {
        Application.Quit();
    }

}
