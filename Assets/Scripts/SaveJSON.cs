using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveJSON : MonoBehaviour
{
    static public void SaveObject(object obj, string path)
    {
        File.WriteAllText(path, JsonUtility.ToJson(obj));
    }
}
