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
    /*
     * ポジションをベクトルにしない理由
     * 
     * 
     */
    public Vector3 _pos;
}
