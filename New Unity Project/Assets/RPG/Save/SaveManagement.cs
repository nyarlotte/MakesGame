using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class SaveManagement : MonoBehaviour
{
    public void Save(SaveData GameSaveData)
    {
        StreamWriter writer;
        string json = JsonUtility.ToJson(GameSaveData);

        writer = new StreamWriter(Application.dataPath + "/RPG/Save" + "/save.json", false);
        writer.Write(json);
        writer.Flush();
        writer.Close();
        Debug.Log(json);
        Debug.Log(Application.dataPath);
    }

    public SaveData Load()
    {
        string data;
        StreamReader _reader;
        _reader = new StreamReader(Application.dataPath + "/RPG/Save" + "/save.json");
        data = _reader.ReadToEnd();
        _reader.Close();
        Debug.Log(data);
        return JsonUtility.FromJson<SaveData>(data);
    }

    // 初期状態のデータを入れる
    public void ResetData()
    {
        SaveData data = new SaveData();
        Save(data);
    }
}
