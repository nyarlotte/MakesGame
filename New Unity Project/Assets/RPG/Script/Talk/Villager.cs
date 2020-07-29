using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Villager : MonoBehaviour
{

    void OnTriggerStay(Collider _col)
    {
        if (_col.gameObject.tag == "Player" && Input.GetMouseButtonDown(0))
        {
            GameObject _player = GameObject.FindGameObjectWithTag("Player");
            CharacterAction _action =_player.GetComponent<CharacterAction>();

            if (_action._state == CharacterAction.State.Move) //SteatがMoveの場合のみ話せるように
            {
                _action._state = CharacterAction.State.Talk;
                SceneManager.LoadScene("Talk", LoadSceneMode.Additive);
                Debug.Log("はなしかけているよ");
            }
        }
    }
}
