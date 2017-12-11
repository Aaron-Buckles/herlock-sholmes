using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public void Fullscreen(bool toggleOn)
    {
        Screen.fullScreen = toggleOn;
    }

}
