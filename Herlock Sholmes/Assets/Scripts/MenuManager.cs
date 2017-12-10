using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    [Tooltip("Element 0 should be the main menu")]
    public GameObject[] menues;


	void Start()
    {
        OpenMenu(0);
    }


    public void OpenMenu(int menuIndex)
    {
        foreach(GameObject menu in menues)
        {
            menu.SetActive(false);
        }

        menues[menuIndex].SetActive(true);
    }

}
