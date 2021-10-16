
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private readonly string _filePath;

    public SaveSystem()
    {
        _filePath = Application.persistentDataPath + "/Save.dat";
    }

    public void Save(SaveData data)
    {
        using (FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, data);
        }
    }

    public SaveData Load()
    {
        SaveData saveData;
        using (FileStream file = File.Open(_filePath, FileMode.Open))
        {
            object loadedData = new BinaryFormatter().Deserialize(file);
            saveData = (SaveData)loadedData;
        }

        return saveData;
    }
}