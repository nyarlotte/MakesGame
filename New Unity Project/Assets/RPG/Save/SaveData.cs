using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //記録させたい情報を適宜追加
    //

    public string _name;
    public int _level;
    public List<bool>_clear;
    public Vector3 _pos;
    public string _sceneName;
    public List<Item> _stock;
}
