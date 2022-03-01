
using UnityEngine;
using UnityEditor;

using System;
using System.IO;
public class JsonToUnity : ISaveSystem
{
    private readonly string filePath;

    public JsonToUnity()
    {
        filePath = Application.persistentDataPath + "/Config.json";
    }

    public SaveData Load()
    {
        string json = "";
        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }
        }

        if (string.IsNullOrEmpty(json))
        {
            return new SaveData();
        }

        return JsonUtility.FromJson<SaveData>(json);
    }

    public void Save(SaveData data)
    {
        var json = JsonUtility.ToJson(data);
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine(json);
        }
    }
}