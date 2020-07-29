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
            Move _move =_player.GetComponent<Move>();

            if (_move._state == Move.State.Move) //SteatがMoveの場合のみ話せるように
            {
                _move._state = Move.State.Talk;
                SceneManager.LoadScene("Talk", LoadSceneMode.Additive);
                Debug.Log("はなしかけているよ");
            }
        }
    }
}
