using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    static public MenuManager instance;

    public GameObject mainMenuPanel;
    public GameObject selectLevelPanel;
    public GameObject stopMenuPanel;
    public GameObject WinPanel;

    public GameObject activePanel;

    private void Awake()
    {
        #region singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        #endregion
        DontDestroyOnLoad(gameObject);
    }

    public void SwitchActivePanel(GameObject panel)
    {
        if (activePanel != null)
            activePanel.SetActive(false);
        activePanel = panel;
        if (activePanel != null)
            panel.SetActive(true);

        /*if (activePanel != mainMenuPanel)
            AdManager.instance.HideBanner();
        else
            AdManager.instance.ShowBanner();*/
    }

    public void OpenWinPanel()
    {
        SwitchActivePanel(WinPanel);
    }

    public void ClearPanels()
    {
        SwitchActivePanel(null);
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(DataManager.instance.data.lastLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
