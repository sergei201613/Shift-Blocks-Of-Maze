using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string path;

    // Data for save.
    [Serializable]
    public class Data
    {
        public List<LevelData> levelsData = new List<LevelData>();
        public int lastLevel = 1;
        [Serializable]
        public class LevelData
        {
            public bool isOpen = false;
            public byte numberOfStars = 0;
        }
    }
    public Data data;

    void Awake()
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

    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        path = Path.Combine(Application.persistentDataPath, "Save.json");

        if (File.Exists(path))
        {
            data = LoadJSON.LoadObject<Data>(path);
        }
        data.levelsData[0].isOpen = true;
    }

    public void SaveGame()
    {
        SaveJSON.SaveObject(data, path);
    }
}
