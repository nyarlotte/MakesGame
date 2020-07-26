using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    SaveManagement _save;
    GameObject Player;

    public void Click()
    {
        /*記録させたい情報を適宜追加
         * レベル　持ち物　自分の場所等
         * 
         * 
         */
        _save = GetComponent<SaveManagement>();
        SaveData _saveData = new SaveData();
        Player = GameObject.FindWithTag("Player");
        _saveData._pos = Player.GetComponent<Transform>().position;
        _save.Save(_saveData);
    }

    public void Load()
    {
        _save = GetComponent<SaveManagement>();
        SaveData _saveData = new SaveData();
        _saveData = _save.Load();
        SceneManager.LoadScene("GameScene");
    }
}
