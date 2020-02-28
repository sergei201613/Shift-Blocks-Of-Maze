using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsContentScript : MonoBehaviour
{
    private int countOfLevels = 0;

    public GameObject levelButtonUI;

    public List<GameObject> btns = new List<GameObject>();

    private void Awake()
    {
        countOfLevels = DataManager.instance.data.levelsData.Count;

        for (int i = 1; i <= countOfLevels; i++)
        {
            GameObject btn = Instantiate(levelButtonUI, transform.position, Quaternion.identity);
            btns.Add(btn);
            btn.SendMessage("SetNumber", i);
            btn.transform.SetParent(transform);
        }
        UpdateLevelsOpennes();
    }

    public void UpdateLevelsOpennes()
    {
        for (int i = 2; i <= countOfLevels; i++)
        {
            btns[i-1].SendMessage("SetIsOpen", DataManager.instance.data.levelsData[i - 1].isOpen);
        }
    }

    private void OnEnable()
    {
        UpdateLevelsOpennes();
    }
}
