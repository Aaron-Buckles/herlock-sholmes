using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{

    public TMP_Text currentResDisplay;

    Resolution[] resolutions;
    int nativeWidth;
    int nativeHeight;

    int currentResIndex = 0;


    void Awake()
    {
        nativeWidth = Screen.currentResolution.width;
        nativeHeight = Screen.currentResolution.height;

        resolutions = Screen.resolutions;
        currentResIndex = FindCurrentResolution();
        DisplayCurrentRes();
    }


    private int FindCurrentResolution()
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution res = resolutions[i];

            if (res.width == nativeWidth && res.height == nativeHeight)
            {
                return i;
            }
        }

        return 0;
    }


    public void NextRes()
    {
        if (currentResIndex >= resolutions.Length - 1)
        {
            currentResIndex = 0;
        }
        else
        {
            currentResIndex += 1;
        }

        DisplayCurrentRes();
    }


    public void PrevRes()
    {
        if (currentResIndex <= 0)
        {
            currentResIndex = resolutions.Length - 1;
        }
        else
        {
            currentResIndex -= 1;
        }

        DisplayCurrentRes();
    }


    private void DisplayCurrentRes()
    {
        Resolution currentRes = resolutions[currentResIndex];
        string width = currentRes.width.ToString();
        string height = currentRes.height.ToString();

        currentResDisplay.text = width + " x " + height;
    }


    public void SetResolution()
    {
        Resolution desiredRes = resolutions[currentResIndex];
        Screen.SetResolution(desiredRes.width, desiredRes.height, Screen.fullScreen);
    }


    public void Fullscreen(bool toggleOn)
    {
        Screen.fullScreen = toggleOn;
    }
}
