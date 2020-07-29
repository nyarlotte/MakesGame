using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    
    ItemList _item;
    GameObject _gm;
    GameObject _player;
    Character _character;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _character = _player.GetComponent<Character>();
        _gm = GameObject.FindGameObjectWithTag("GM");
        _item = _gm.GetComponent<ItemList>();
    }
    void OnTriggerStay(Collider _col)
    {
        if (_col.gameObject.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            CharacterAction _action = _player.GetComponent<CharacterAction>();
            
            if (_action._state == CharacterAction.State.Move) //SteatがMoveの場合のみ話せるように
            {
               _action._type = 1;
               _action._state = CharacterAction.State.Talk;
               _character._stock.Add(_item._itemList[0]);
               Debug.Log(_item._itemList[0]._name);
            }
        }
    }
}
