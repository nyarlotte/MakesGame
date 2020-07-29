using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Object/Item")]
public class Item : ScriptableObject
{
    public　int _id;
    public  string _name; //アイテム名
    public  int _type;　　//　アイテムの効果を種別　　
    public  float _effect;　　　//　アイテムの効果
    public  int _effectTime;　　//　アイテム効果時間　
    public  string _explanation;　//　アイテムの説明

    /*_type 値　
     * 0　回復薬
     * 1　バフ
     * 2　攻撃アイテム
     * 
     */
}
