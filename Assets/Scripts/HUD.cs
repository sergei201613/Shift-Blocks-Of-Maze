using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text timeText;

    private void Update()
    {
        if (!GameMode.instance.gameIsEnd)
        {
            timeText.text = "time: " + Mathf.Floor(Time.timeSinceLevelLoad).ToString();
        }
    }

    public void Menu()
    {
        MenuManager.instance.SwitchActivePanel(MenuManager.instance.stopMenuPanel);
    }
}
