using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour {

    public TMP_Dropdown resDropdown;

    Resolution[] resolutions;
    int nativeWidth;
    int nativeHeight;


    void Awake()
    {
        nativeWidth = Screen.currentResolution.width;
        nativeHeight = Screen.currentResolution.height;

        resolutions = Screen.resolutions;
        PopulateResDropdown();
    }


    private void PopulateResDropdown()
    {
        int resIndex = 0;

        resDropdown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution res = resolutions[i];

            if (res.width == nativeWidth && res.height == nativeHeight)
            {
                resIndex = i;
            }

            AddResolution(res);
        }

        resDropdown.value = resIndex;
        resDropdown.RefreshShownValue();
    }


    private void AddResolution(Resolution res)
    {
        resDropdown.options.Add(new TMP_Dropdown.OptionData { text = res.width + " x " + res.height });
    }


    public void Fullscreen(bool toggleOn)
    {
        Screen.fullScreen = toggleOn;
    }


    public void SetResolution(int resIndex)
    {
        Resolution desiredRes = resolutions[resIndex];
        Screen.SetResolution(desiredRes.width, desiredRes.height, Screen.fullScreen);
    }

}
