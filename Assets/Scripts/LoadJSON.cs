using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadJSON : MonoBehaviour
{
    static public T LoadObject<T>(string path)
    {
        if (File.Exists(path))
        {
            return JsonUtility.FromJson<T>(File.ReadAllText(path));
        }
        else
        {
            return default;
        }
    }
}
